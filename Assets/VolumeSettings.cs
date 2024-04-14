using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;

    public void SetMasterVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(volume)*20);
    }
}
