using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderWord : MonoBehaviour
{
    bool isHide;
    public void Protect()
    {
        GetComponent<Animator>().Play("Protect", 0, 0);
    }

    void Update()
    {
        if (isHide && Character.instance.wordHolder.current.name != "雳")
        {
            GetComponent<Collider2D>().enabled = true;
            GetComponent<Animator>().Play("Show");
            isHide = false;
        }
        else if (!isHide && Character.instance.wordHolder.current.name == "雳")
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Animator>().Play("Hide");
            isHide = true;
        }
    }
}
