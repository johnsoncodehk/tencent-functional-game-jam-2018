using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneLamp : MonoBehaviour
{
    public StoneLamp other;
    public bool isHide;
    public void OnTakeWord()
    {
        isHide = true;
        GetComponent<Animator>().Play("Hide");
        if (other.isHide)
            other.Show();
    }
    void Show()
    {
        isHide = false;
        GetComponent<Animator>().Play("Show");
    }
}
