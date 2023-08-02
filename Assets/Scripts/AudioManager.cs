using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soundsEfects;

    public AudioSource bgmusic, levelEndMusic,bgMenu;

    public AudioSource[] steps;

    private void Awake() 
    {
        instance = this;
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlaySFX(int soundToPlay)
    {
        soundsEfects[soundToPlay].Stop();

        soundsEfects[soundToPlay].pitch = Random.Range(.9f, 1.1f);

        soundsEfects[soundToPlay].Play();
    }

    public void PlaySteps(int stepToPlay)
    {
        steps[stepToPlay].Play();
    }

}
