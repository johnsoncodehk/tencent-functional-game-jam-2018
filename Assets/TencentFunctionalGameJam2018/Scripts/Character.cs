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
    public float jumpHeight;

    /* Runtime Propertys */
    public GameData gameData;
    public List<Word> touchingWords;

    /* Getter/Setter Propertys */
    public Word otherTouchingWord
    {
        get
        {
            touchingWords = touchingWords.FindAll(word => !!word);
            foreach (Word word in touchingWords)
                if (word != wordHolder.current)
                    return word;
            return null;
        }
    }

    /* Unity Events */
    void Awake()
    {
        gameData = Resources.Load<GameData>("GameData");
        ResetWord();
    }
    void Update()
    {
        UpdateHorizontal();
        UpdateJump();
        UpdateGrounded();
        UpdateState();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Word otherWord = other.GetComponent<Word>();
        if (otherWord)
            touchingWords.Add(otherWord);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Word otherWord = other.GetComponent<Word>();
        if (otherWord)
            touchingWords.Remove(otherWord);
    }

    /* Animation Events */
    void OnJump()
    {
        animator.Play("Falling", 0);
        float vy = Mathf.Sqrt(-2 * Physics2D.gravity.y * Mathf.Abs(jumpHeight)) * (jumpHeight < 0 ? -1 : 1);
        rigidbody.AddForce(new Vector2(0, vy), ForceMode2D.Impulse);
    }

    /* Public */
    public void CombineWords()
    {
        Word otherWord = otherTouchingWord;
        if (otherWord)
        {
            foreach (WordCombine wordCombine in gameData.wordCombines)
            {
                List<string> remainWords = wordCombine.combineFromWords.ToList();

                if (!remainWords.Remove(otherWord.text))
                    continue;
                if (!remainWords.Remove(wordHolder.current.text))
                    continue;

                wordHolder.ChangeWord(wordCombine.word);
            }
        }
    }
    public void ResetWord()
    {
        wordHolder.ChangeWord(startWord);
    }

    /* Internal */
    void UpdateHorizontal()
    {
        int raw = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        animator.SetInteger("Horizontal", raw);
    }
    void UpdateJump()
    {
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
            animator.SetTrigger("Jump");
    }
    void UpdateState()
    {
        AnimatorStateInfo currentState = animator.GetNextAnimatorStateInfo(0);
        if (currentState.fullPathHash == 0)
            currentState = animator.GetCurrentAnimatorStateInfo(0);

        int raw = 0;
        if (currentState.IsName("Walk"))
        {
            raw = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
            if (raw != 0)
                transform.localScale = new Vector3(raw, 1, 1);
        }
        JointMotor2D motor = footHingeJoint.motor;
        motor.motorSpeed = raw * 600;
        footHingeJoint.motor = motor;
    }
    void UpdateGrounded()
    {
        animator.SetBool("Is Grounded", groundCheck.isGrounded);
    }
}
