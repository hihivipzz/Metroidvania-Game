using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        musicSlider.value = MusicManager.Instance.volume;
        sfxSlider.value = SoundManager.Instance.volume;
    }

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(delegate { ChangeMusicVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { ChangeSFXVolume(); });
    }

    public void ChangeMusicVolume()
    {
        MusicManager.Instance.SetVolume(musicSlider.value);
    }

    public void ChangeSFXVolume()
    {
        SoundManager.Instance.SetVolume(sfxSlider.value);
    }

}
