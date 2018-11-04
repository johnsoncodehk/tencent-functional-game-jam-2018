using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCloud : MonoBehaviour
{
    public void Thunder()
    {
        GetComponent<Animator>().Play("Thunder", 0, 0);
    }
}
