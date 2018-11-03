using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    /* Config Propertys */
    public Animator animator;
    new public Rigidbody2D rigidbody;
    public HingeJoint2D footHingeJoint;
    public Word startWord;
    public WordHolder wordHolder;
    public GroundCheck groundCheck;
    public Vector2 jumpLength;
    public float maximumAeriallyMovementSpeed = 2; // 空中移動最大速度
    public float aeriallyMovementAcceleration = 1; // 空中移動加速度
    public StageMask stageMask;

    /* Runtime Propertys */
    GameData m_GameData;
    List<Word> m_TouchingWords = new List<Word>();

    /* Getter/Setter Propertys */
    public Word otherTouchingWord
    {
        get
        {
            m_TouchingWords = m_TouchingWords.FindAll(word => !!word);
            foreach (Word word in m_TouchingWords)
                if (word != wordHolder.current)
                    return word;
            return null;
        }
    }

    /* Unity Events */
    void Awake()
    {
        m_GameData = Resources.Load<GameData>("GameData");
        stageMask.gameObject.SetActive(true);
        ResetWord();
    }
    void Update()
    {
        UpdateHorizontal();
        UpdateInputButton();
        UpdateGrounded();
        UpdateState();
        UpdateSpeedY();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Word otherWord = other.GetComponent<Word>();
        if (otherWord)
            m_TouchingWords.Add(otherWord);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Word otherWord = other.GetComponent<Word>();
        if (otherWord)
            m_TouchingWords.Remove(otherWord);
    }

    /* Animation Events */
    void OnJump()
    {
        animator.Play("Falling", 0);
        float vy = Mathf.Sqrt(-2 * Physics2D.gravity.y * Mathf.Abs(jumpLength.y)) * (jumpLength.y < 0 ? -1 : 1);
        float vx = jumpLength.x * Physics2D.gravity.y / (-2 * vy) * (jumpLength.y < 0 ? -1 : 1);
        float rawX = Input.GetAxisRaw("Horizontal");
        rigidbody.AddForce(new Vector2(vx * rawX, vy), ForceMode2D.Impulse);
    }

    /* Public */
    public void CombineWords()
    {
        Word otherWord = otherTouchingWord;
        if (otherWord)
        {
            foreach (WordCombine wordCombine in m_GameData.wordCombines)
            {
                List<string> remainWords = wordCombine.combineFromWords.ToList();

                if (!remainWords.Remove(otherWord.name))
                    continue;
                if (!remainWords.Remove(wordHolder.current.name))
                    continue;

                wordHolder.ChangeWord(wordCombine.word);
            }
            GameObject ag = GameObject.FindWithTag("AudioController");
            AudioController ac = (AudioController)ag.GetComponent(typeof(AudioController));
            ac.LvlUp();
        }
    }
    public void ResetWord()
    {
        wordHolder.ChangeWord(startWord);
        GameObject ag = GameObject.FindWithTag("AudioController");
        AudioController ac = (AudioController)ag.GetComponent(typeof(AudioController));
        ac.LvlDown();
    }

    /* Internal */
    void UpdateInputButton()
    {
        if (Input.GetButtonDown("Fire1") && !!otherTouchingWord)
            CombineWords();
        if (Input.GetButtonDown("Fire2") && wordHolder.current.name != startWord.name)
            ResetWord();
        if (Input.GetButtonDown("Fire3"))
        {
            if (wordHolder.current.name == "日")
            {
                stageMask.PlayLight();
            }
            else if (wordHolder.current.name == "灭")
            {
                print("灭");
            }
            else if (wordHolder.current.name == "飞")
            {
                print("飞");
            }
            else if (wordHolder.current.name == "雳")
            {
                print("雳");
            }
        }
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
            animator.SetTrigger("Jump");
    }
    void UpdateHorizontal()
    {
        int raw = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        animator.SetInteger("Horizontal", raw);
    }
    void UpdateState()
    {
        AnimatorStateInfo currentState = animator.GetNextAnimatorStateInfo(0);
        if (currentState.fullPathHash == 0)
            currentState = animator.GetCurrentAnimatorStateInfo(0);

        int moveRaw = 0;
        if (currentState.IsName("Walk"))
        {
            moveRaw = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
            if (moveRaw != 0)
                transform.localScale = new Vector3(moveRaw, 1, 1);
        }
        else if (currentState.IsName("Falling") || currentState.IsName("Falling_Down"))
        {
            int rawX = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
            if (rawX != 0)
            {
                transform.localScale = new Vector3(rawX, 1, 1);

                if (transform.localScale.x > 0 ? rigidbody.velocity.x < maximumAeriallyMovementSpeed : rigidbody.velocity.x > -maximumAeriallyMovementSpeed)
                    rigidbody.velocity += new Vector2(aeriallyMovementAcceleration * Time.deltaTime * transform.localScale.x, 0);
            }
        }
        JointMotor2D motor = footHingeJoint.motor;
        motor.motorSpeed = moveRaw * 600;
        footHingeJoint.motor = motor;
    }
    void UpdateSpeedY()
    {
        animator.SetFloat("vy", rigidbody.velocity.y);
    }
    void UpdateGrounded()
    {
        animator.SetBool("Is Grounded", groundCheck.isGrounded);
    }
}
