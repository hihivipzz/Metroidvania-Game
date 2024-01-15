using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSouce;
    [SerializeField] private AudioClipRefsSO audioClip;
    public float volume = 10f;
    // Start is called before the first frame update

    private void Awake()
    {
        audioSouce = GetComponent<AudioSource>();
        audioSouce.volume = volume;
        audioSouce.clip = audioClip.IntroMusic;
        audioSouce.Play();
    }
    void Start()
    {
        BossAwakeState.OnBossAwake += BossAwakeState_OnBossAwake;
        BossDeadState.OnBossDeadState += BossDeadState_OnBossDeadState;
        BossSleepState.OnBossSleep += BossSleepState_OnBossSleep;
    }

    private void BossSleepState_OnBossSleep(object sender, System.EventArgs e)
    {
        audioSouce.clip = audioClip.IntroMusic;
        audioSouce.Play();
    }

    private void BossDeadState_OnBossDeadState(object sender, System.EventArgs e)
    {
        audioSouce.clip = audioClip.IntroMusic;
        audioSouce.Play();
    }

    private void BossAwakeState_OnBossAwake(object sender, System.EventArgs e)
    {
        audioSouce.clip = audioClip.BossMusic;
        audioSouce.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
