using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Animator>().Play("Wind_" + Random.Range(1, 4));
    }
    void Done()
    {
        Destroy(gameObject);
    }
}
