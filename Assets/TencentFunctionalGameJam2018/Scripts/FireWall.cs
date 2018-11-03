using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    public static FireWall instance;
    void Awake()
    {
        instance = this;
    }
    public void Close()
    {
        GetComponent<Animator>().Play("Close");
    }
}
