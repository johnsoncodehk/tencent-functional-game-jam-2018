using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordLight : MonoBehaviour
{

    public Transform o;
    public SpriteRenderer[] lightSprites;

    float v;

    void Update()
    {
        if (Character.instance.wordHolder.current.name == "日")
        {
            GetComponent<SpriteRenderer>().enabled = false;

            float targetA = 0;
            float a = Mathf.SmoothDamp(lightSprites[0].color.a, targetA, ref v, 0.1f);
            foreach (var light in lightSprites)
                light.color = new Color(1, 1, 1, a);
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;

            float d = Vector2.Distance(Character.instance.transform.position, o.position);
            float targetA = 1 - d / 3;
            float a = Mathf.SmoothDamp(lightSprites[0].color.a, targetA, ref v, 0.1f);
            foreach (var light in lightSprites)
                light.color = new Color(1, 1, 1, a);
        }
    }
}
