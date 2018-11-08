using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameOver : MonoBehaviour
{

    public static CheckGameOver instance;

    public GameObject characterDeadEffect;
    public bool isGameOver;

    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (!isGameOver)
        {
            if (Character.instance.transform.position.y < -1)
                GameOver();
        }
    }
    void OnShow()
    {
        if (isGameOver)
        {
            GetComponent<Animator>().Play("Hide");

            Character.instance.enabled = true;
            Character.instance.rigidbody.bodyType = RigidbodyType2D.Dynamic;
            Character.instance.animator.speed = 1;
            Character.instance.spriteMeshes.SetActive(true);
            // Character.instance.transform.localEulerAngles = new Vector3(0, 0, 0);
            // Character.instance.transform.localScale = Vector3.one;
            Character.instance.Restart();

            isGameOver = false;
        }
    }
    void OnFinish()
    {
        GameStart.gameFinish = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameStart");
    }

    public void GameOver()
    {
        Character.instance.enabled = false;
        Character.instance.rigidbody.bodyType = RigidbodyType2D.Static;
        Character.instance.animator.speed = 0;
        Character.instance.spriteMeshes.SetActive(false);
        Character.instance.deadEffectAnimator.Play("Flash", 0, 0);
        // Character.instance.transform.localEulerAngles = new Vector3(0, 0, 90);
        // Character.instance.transform.localScale = Vector3.zero;

        isGameOver = true;
        GetComponent<Animator>().Play("Show");

        // StartCoroutine(ShowEffect());
    }
    public void GameFinish()
    {
        transform.parent.SetParent(null);
        GetComponent<Animator>().Play("Finish");
    }

    IEnumerator ShowEffect()
    {
        GameObject effect = Instantiate(characterDeadEffect);
        effect.transform.position = Character.instance.transform.position;
        yield return new WaitForSeconds(5);
        Destroy(effect);
    }
}
