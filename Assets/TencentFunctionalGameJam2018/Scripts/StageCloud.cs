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
        GameObject ag = GameObject.FindWithTag("AudioController");
        AudioController ac = (AudioController)ag.GetComponent(typeof(AudioController));
        ac.PlayRain();
        foreach (var effect in rain.GetComponentsInChildren<ParticleSystem>())
            effect.Play();
    }
    public void RainEnd()
    {
        GameObject ag = GameObject.FindWithTag("AudioController");
        AudioController ac = (AudioController)ag.GetComponent(typeof(AudioController));
        ac.StopRain();
        foreach (var effect in rain.GetComponentsInChildren<ParticleSystem>())
            effect.Stop();
    }
}
