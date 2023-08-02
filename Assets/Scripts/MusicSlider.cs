using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void ControlMaster (float sliderMaster)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(sliderMaster) * 20);
    }
    public void ControlMusic(float sliderMusic)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(sliderMusic) * 20);
    }
    public void ControlSFX(float sliderSFX)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(sliderSFX) * 20);
    }
}
