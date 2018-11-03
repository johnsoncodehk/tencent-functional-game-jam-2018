using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip dropSound1;
    public AudioClip dropSound2;
    public AudioClip dropSound3;
    public AudioClip background1;
    public AudioClip background2;
    public AudioClip state1;
    public AudioClip state2;
    public AudioClip state3;
    public AudioClip state4;
    public AudioClip transformUp;
    public AudioClip transformDown;
    public AudioClip shining;
    public AudioClip extinguish;
    public int lvl = 1;
    public int lvlState = 0;

    private AudioSource[] sources;
    private float volLowRange = .2f;
    private float volHighRange = 1.0f;
    private float pitchLowRange = .1f;
    private float pitchHighRange = 1.0f;
    private int interval = 188;
    private AudioClip[] lvlMusic;

    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();
        PlayLvlAmbiance(lvl);
        PlayLvlBGM(lvl);
    }

    void Update()
    {
        if (lvl == 1)
        {
            if (Time.frameCount % interval == 0)
            {
                if (Random.value < .5)
                {
                    PlaySoundRnd(dropSound1);
                }
            }
            else if (Time.frameCount % interval == 100)
            {
                if (Random.value < .5)
                {
                    PlaySoundRnd(dropSound2);
                }
            }
            else if (Time.frameCount % interval == 66)
            {
                if (Random.value < .5)
                {
                    PlaySoundRnd(dropSound3);
                }
            }
        }
    }

    // Update is called once per frame
    void PlaySoundRnd(AudioClip sound)
    {
        float vol = Random.Range(volLowRange, volHighRange);
        sources[1].pitch = Random.Range(pitchLowRange, pitchHighRange);
        sources[1].PlayOneShot(sound, vol);
    }

    //
    void PlayLvlBGM(int bgmLvl)
    {
        if (bgmLvl == 1)
        {
            lvlMusic = new AudioClip[] { state1, state2, state3, state4 };
        }
        else if (lvl == 2)
        {
            lvlMusic = new AudioClip[] { state1, state2, state3, state4 };
        }
        else
        {
            lvlMusic = new AudioClip[] { state1, state2, state3, state4 };
        }
        sources[2].clip = lvlMusic[lvlState];
        sources[2].Play();
    }

    //
    void PlayLvlAmbiance(int ambLvl)
    {
        if (ambLvl == 1)
        {
            sources[0].clip = background1;
            sources[0].Play();
        }
        else
        {
            sources[0].clip = background2;
            sources[0].Play();
        }
    }

    //
    public void LvlUp()
    {
        if (lvlState<3)
        {
            sources[3].PlayOneShot(transformUp);
            lvlState = lvlState + 1;
            float FadeTime = 1.0f;
            float startVolume = sources[2].volume;

            while (sources[2].volume > 0)
            {
                sources[2].volume -= startVolume * Time.deltaTime / FadeTime;

                //yield return null;
            }
            sources[2].Stop();
            sources[2].clip = lvlMusic[lvlState];
            sources[2].Play();
            while (sources[2].volume < startVolume)
            {
                sources[2].volume += startVolume * Time.deltaTime / FadeTime;
                //yield return null;
            }

        }

        
    }

    //
    public void LvlDown()
    {

        if (lvlState > 0)
        {
            sources[3].PlayOneShot(transformDown);
            lvlState = 0;
            float FadeTime = 1.0f;
            float startVolume = sources[2].volume;

            while (sources[2].volume > 0)
            {
                sources[2].volume -= startVolume * Time.deltaTime / FadeTime;

                //yield return null;
            }
            sources[2].Stop();
            sources[2].clip = lvlMusic[0];
            sources[2].Play();
            while (sources[2].volume < startVolume)
            {
                sources[2].volume += startVolume * Time.deltaTime / FadeTime;
                //yield return null;
            }
        }
    }

    public void PlayFx()
    {

    }
}
