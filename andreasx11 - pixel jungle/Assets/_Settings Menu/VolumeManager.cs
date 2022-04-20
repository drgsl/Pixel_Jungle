using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static Slider volumeSlider;

    [Range(4, 80)]
    public int steps = 4;

    private int volumeFactor;


    private void Awake()
    {
        volumeSlider = GetComponent<Slider>();//GameObject.FindGameObjectWithTag("MainMenu/Settings/VolumeSlider").GetComponent<Slider>();
        //volumeFactor = 80 / steps;
        //volumeSlider.minValue = - volumeFactor;

        //todo:find audiomixer
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
}
