using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    private float volume = 1;

    private void Awake()
    {
        Instance= this;
    }

    private void Start()
    {
        volume = 1;
        Coin.onPickUpCoin += Coin_onPickUpCoin;
        PlayerMovementController.OnDashing += PlayerMovementController_onDashing;
        PlayerMovementController.OnJumping += PlayerMovementController_OnJumping;
        PlayerMovementController.OnWallJumping += PlayerMovementController_OnWallJumping;
        PlayerMovementController.OnKnockBack += PlayerMovementController_OnKnockBack;
        PlayerCombatController.OnParrySuccess += PlayerCombatController_OnParrySuccess;

    }

    private void PlayerMovementController_OnKnockBack(object sender, System.EventArgs e)
    {
        PlayerMovementController player = sender as PlayerMovementController;
        PlaySound(audioClipRefsSO.playerHurtSound, player.transform.position);
    }

    private void PlayerCombatController_OnParrySuccess(object sender, System.EventArgs e)
    {
        PlayerCombatController player = sender as PlayerCombatController;
        PlaySound(audioClipRefsSO.parrySuccess, player.transform.position);
    }

    private void PlayerMovementController_OnWallJumping(object sender, System.EventArgs e)
    {
        PlayerMovementController player = sender as PlayerMovementController;
        PlaySound(audioClipRefsSO.playerWallJump, player.transform.position);
    }

    private void PlayerMovementController_OnJumping(object sender, System.EventArgs e)
    {
        PlayerMovementController player = sender as PlayerMovementController;
        PlaySound(audioClipRefsSO.playerJump, player.transform.position);
    }

    private void PlayerMovementController_onDashing(object sender, System.EventArgs e)
    {
        PlayerMovementController player = sender as PlayerMovementController;
        PlaySound(audioClipRefsSO.playerDashing, player.transform.position);
    }

    private void Coin_onPickUpCoin(object sender, System.EventArgs e)
    {
        Coin coin = sender as Coin;
        PlaySound(audioClipRefsSO.coinPickUp, coin.transform.position, volume);
    }

    private void PlaySound(AudioClip[] audioClips, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClips[Random.Range(0,audioClips.Length)],position, volume);  
    }

    private void PlaySound(AudioClip audioClip,Vector3 position, float  volume=1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    public void PlayFootstepSound(Vector3 position)
    {
        PlaySound(audioClipRefsSO.playerFootstep, position, volume);
    }
}
