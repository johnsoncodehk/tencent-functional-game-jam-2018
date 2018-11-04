using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFoot : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        StageCloud cloud = other.collider.GetComponent<StageCloud>();
        if (cloud)
        {
            if (Character.instance.wordHolder.current.name == "雨")
            {
                // 下雨
                cloud.RainStart();
            }
            else
            {
                cloud.Thunder();
                CheckGameOver.instance.GameOver();
            }
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        StageCloud cloud = other.collider.GetComponent<StageCloud>();
        if (cloud)
        {
            cloud.RainEnd();
        }
    }
}
