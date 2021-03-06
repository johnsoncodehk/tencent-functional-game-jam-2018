﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLightning : MonoBehaviour
{

    public float delayTime;
    public float length = 2;
    public bool isDragon;

    void Awake()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    public void StartLightning()
    {
        StartCoroutine(StartLightningCoroutine());
    }
    IEnumerator StartLightningCoroutine()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        yield return new WaitForSeconds(delayTime);

        if (isDragon) {
            GameObject ag = GameObject.FindWithTag("AudioController");
            AudioController ac = (AudioController)ag.GetComponent(typeof(AudioController));
            ac.PlayFx("dragon");
        }

        float startTime = Time.time;
        while (Time.time - startTime < length)
        {
            int randomNum = Random.Range(1, 5);

            for (int i = 0; i < randomNum; i++)
            {
                sprite.enabled = false;
                yield return new WaitForSeconds(0.02f);
                sprite.enabled = true;
                yield return new WaitForSeconds(0.02f);
            }

            yield return new WaitForSeconds(Random.Range(0f, 1f));
        }
    }
}
