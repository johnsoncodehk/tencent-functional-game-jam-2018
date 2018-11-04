using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    public static bool gameFinish;

    void Awake() {
        if (!gameFinish)
            GetComponent<Animator>().Play("Start");
    }
    void Update()
    {
        if (Input.GetButtonDown("Y"))
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }
}
