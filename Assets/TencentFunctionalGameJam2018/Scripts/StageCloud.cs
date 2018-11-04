using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCloud : MonoBehaviour
{

    public GameObject rain;

    void Awake()
    {
        foreach (var effect in rain.GetComponentsInChildren<ParticleSystem>())
            effect.Stop();
    }

    public void Thunder()
    {
        GetComponent<Animator>().Play("Thunder", 0, 0);
    }
    public void RainStart()
    {
        foreach (var effect in rain.GetComponentsInChildren<ParticleSystem>())
            effect.Play();
    }
    public void RainEnd()
    {
        foreach (var effect in rain.GetComponentsInChildren<ParticleSystem>())
            effect.Stop();
    }
}
