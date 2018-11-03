using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordLight : MonoBehaviour
{

    public Transform character;
    public Transform o;
    public SpriteRenderer lightSprite;

    void Update()
    {
        float d = Vector2.Distance(character.position, o.position);
        lightSprite.color = new Color(1, 1, 1, 1 - d / 4);
    }
}
