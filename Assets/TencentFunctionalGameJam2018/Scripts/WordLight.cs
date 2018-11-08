using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordLight : MonoBehaviour
{

    public Transform o;
    public SpriteRenderer[] lightSprites;
    public bool isWord = true;
    public float alpha = 1;

    float v;

    void Update()
    {
        if (isWord)
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
        else
        {
            if (Character.instance.wordHolder.current.name != "日")
            {
                float targetA = 0;
                float a = Mathf.SmoothDamp(lightSprites[0].color.a, targetA, ref v, 0.1f);
                a *= alpha;
                foreach (var light in lightSprites)
                    light.color = new Color(1, 1, 1, a);
            }
            else
            {
                float d = Vector2.Distance(Character.instance.transform.position, o.position);
                float targetA = 1 - d / 3;
                float a = Mathf.SmoothDamp(lightSprites[0].color.a, targetA, ref v, 0.1f);
                a *= alpha;
                foreach (var light in lightSprites)
                    light.color = new Color(1, 1, 1, a);
            }
        }
    }
}
