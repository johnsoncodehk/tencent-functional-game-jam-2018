using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameOver : MonoBehaviour
{

    public static CheckGameOver instance;

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
        GetComponent<Animator>().Play("Hide");

        Character.instance.enabled = true;
        Character.instance.rigidbody.bodyType = RigidbodyType2D.Dynamic;
        Character.instance.animator.speed = 1;
        Character.instance.Restart();

        isGameOver = false;
    }

    public void GameOver()
    {
        Character.instance.enabled = false;
        Character.instance.rigidbody.bodyType = RigidbodyType2D.Static;
        Character.instance.animator.speed = 0;

        isGameOver = true;
        GetComponent<Animator>().Play("Show");
    }
}
