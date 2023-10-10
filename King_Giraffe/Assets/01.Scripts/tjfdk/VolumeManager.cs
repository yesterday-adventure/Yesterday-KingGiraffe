using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    public void SetBGMVolume() {

        float value = bgmSlider.value;
        masterMixer.SetFloat("BGM", value);
    }

    public void SetSFXVolume() {

        float value = sfxSlider.value;
        masterMixer.SetFloat("SFX", value);
    }
}
