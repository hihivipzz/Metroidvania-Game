using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private void Start()
    {
        
    }

    private void PlaySound(AudioClip[] audioClips, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClips[Random.Range(0,audioClips.Length)],position, volume);  
    }

    private void PlaySound(AudioClip audioClip,Vector3 position, float  volume=1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
