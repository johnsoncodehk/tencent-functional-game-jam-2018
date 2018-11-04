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
        Character.instance.Restart();

        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        GetComponent<Animator>().Play("Show");
    }
}
