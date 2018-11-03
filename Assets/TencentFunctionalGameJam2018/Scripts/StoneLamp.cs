using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneLamp : MonoBehaviour
{
    public void HideFire()
    {
        GetComponent<Animator>().Play("Hide");
    }
}
