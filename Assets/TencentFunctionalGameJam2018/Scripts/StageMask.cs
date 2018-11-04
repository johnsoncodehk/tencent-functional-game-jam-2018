using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMask : MonoBehaviour
{
    public bool PlayLight()
    {
        var state = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Light") && state.normalizedTime < 0.3f)
            return false;
        GetComponent<Animator>().Play("Light", 0, 0);
        return true;
    }
    public void PlayLightFinal()
    {
        GetComponent<Animator>().Play("Light_Final");
    }
}
