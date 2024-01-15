using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipRefsSO : ScriptableObject
{
    public AudioClip IntroMusic;
    public AudioClip BossMusic;

    public AudioClip[] playerFootstep;
    public AudioClip coinPickUp;
    public AudioClip playerJump;
    public AudioClip playerWallJump;
    public AudioClip playerDashing;
    public AudioClip parrySuccess;
    public AudioClip playerSpell;
    public AudioClip[] playerAttack;
    public AudioClip playerHurtSound;

    public AudioClip buySuccess;
    public AudioClip buyFail;
}
