using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGiver : MonoBehaviour
{
    public string word;
    public void Take()
    {
        gameObject.SendMessage("OnTakeWord", SendMessageOptions.DontRequireReceiver);
    }
}
