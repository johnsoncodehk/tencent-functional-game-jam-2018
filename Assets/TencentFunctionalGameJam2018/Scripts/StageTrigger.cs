using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTrigger : MonoBehaviour
{
    public string id = "level_1_light";
    public bool isOn
    {
        get;
        private set;
    }
    public void On()
    {
        isOn = true;
        GetComponent<Animator>().Play("Close");
    }
}
