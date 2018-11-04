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
    public AudioClip state5;
    public AudioClip state6;
    public AudioClip state7;
    public AudioClip state8;


    public AudioClip transformUp;
    public AudioClip transformDown;
    public AudioClip shining;
    public AudioClip extinguish;
    public AudioClip bird;
    public AudioClip thunder;
    public AudioClip rain;
    public AudioClip wind;
    public AudioClip neon;

    public int lvl = 1;
    public int lvlState = 0;
    public float rainVolume = 0.2f;

    private AudioSource[] sources;
    Dictionary<string, AudioClip> clips;
    Dictionary<string, AudioClip> sndFx;
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
        //if (bgmLvl == 1)
        //{
        //    lvlMusic = new AudioClip[] { state1, state2, state3, state4 };
        //}
        //else if (lvl == 2)
        //{
        //    lvlMusic = new AudioClip[] { state1, state2, state3, state4 };
        //}
        //else
        //{
        //    lvlMusic = new AudioClip[] { state1, state2, state3, state4 };
        //}
        clips = new Dictionary<string, AudioClip>{ { "reset",state1 },
            {"",state2}, {"日", state3 }, {"灭", state4 }, { "飞", state5 }, {"reset2",state6}, { "雨", state7 }, { "雳", state8 } };
        sndFx = new Dictionary<string, AudioClip>{ { "transformUp",transformUp },
            {"transformDown",transformDown}, {"shining", shining }, {"extinguish", extinguish }, { "bird", bird }, {"thunder",thunder}, { "rain", rain }, { "neon", neon },{ "wind", wind } };
        sources[2].clip = clips["reset"];
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

            sources[0].Stop();
        }
    }
    public void PutOutFire(){
        lvl = 2;
        PlayFx("extinguish");
        PlayLvlAmbiance(2);
    }
    //
    public void LvlUp(string lvlId)
    {
            lvlState = 1;
            sources[3].PlayOneShot(transformUp);
            float FadeTime = 1.0f;
            float startVolume = sources[2].volume;
            while (sources[2].volume > 0)
            {
                sources[2].volume -= startVolume * Time.deltaTime / FadeTime;

                //yield return null;
            }
            sources[2].Stop();
            if (clips.ContainsKey(lvlId))
            {
                sources[2].clip = clips[lvlId];
            }
            sources[2].Play();
            while (sources[2].volume < startVolume)
            {
                sources[2].volume += startVolume * Time.deltaTime / FadeTime;
                //yield return null;
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
            if(lvl == 1){
                sources[2].clip = clips["reset"];

            }else{
                //sources[2].clip = clips["reset2"];

            }
            sources[2].Play();
            while (sources[2].volume < startVolume)
            {
                sources[2].volume += startVolume * Time.deltaTime / FadeTime;
                //yield return null;
            }
        }
    }

    public void PlayFx(string soundFx)
    {
        //if (!sources[3].isPlaying)
        //{
            sources[3].PlayOneShot(sndFx[soundFx]);
        //}

    }

    public void PlayRain(){
            float FadeTime = 2.0f;
            float startVolume = rainVolume;
            while (sources[4].volume < startVolume)
            {
                sources[4].volume += startVolume * Time.deltaTime / FadeTime;
                //yield return null;
            }
    }

    public void StopRain()
    {
        float FadeTime = 2.0f;
        float startVolume = sources[4].volume;
        while (sources[4].volume > 0)
        {
            sources[4].volume -= startVolume * Time.deltaTime / FadeTime;
            //yield return null;
        }

    }
}
