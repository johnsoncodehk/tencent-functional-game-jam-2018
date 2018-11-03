using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordLight : MonoBehaviour
{

    public Character character;
    public Transform o;
    public SpriteRenderer[] lightSprites;

    void Update()
    {
        if (character.wordHolder.current.name == "日")
        {
            foreach (var light in lightSprites)
                light.color = new Color(1, 1, 1, 0);
        }
        else
        {
            float d = Vector2.Distance(character.transform.position, o.position);
            foreach (var light in lightSprites)
                light.color = new Color(1, 1, 1, 1 - d / 4);
        }
    }
}
