using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    public float volume = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance && Instance != null)
        {
            Destroy(this.gameObject);
        }
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
        PlayerSpell.OnSpellTrigger += PlayerSpell_OnSpellTrigger;
        PlayerAttack.OnPlayerAttack += PlayerAttack_OnPlayerAttack;
        StoreManager.OnBuySuccess += StoreManager_OnBuySuccess;
        StoreManager.OnBuyError += StoreManager_OnBuyError;

    }

    private void StoreManager_OnBuyError(object sender, System.EventArgs e)
    {
        StoreManager store = sender as StoreManager;
        PlaySound(audioClipRefsSO.buyFail,Camera.main.transform.position,volume);
    }

    private void StoreManager_OnBuySuccess(object sender, System.EventArgs e)
    {
        Debug.Log(1);
        StoreManager store = sender as StoreManager;
        PlaySound(audioClipRefsSO.buySuccess, Camera.main.transform.position,volume);
    }

    private void PlayerAttack_OnPlayerAttack(object sender, System.EventArgs e)
    {
        PlayerAttack attack = sender as PlayerAttack;
        PlaySound(audioClipRefsSO.playerAttack, attack.GetAttackPos(), volume);
    }

    private void PlayerSpell_OnSpellTrigger(object sender, System.EventArgs e)
    {
        PlayerSpell spell = sender as PlayerSpell;
        PlaySound(audioClipRefsSO.playerSpell, spell.GetAttackPos(),volume);
    }

    private void PlayerMovementController_OnKnockBack(object sender, System.EventArgs e)
    {
        PlayerMovementController player = sender as PlayerMovementController;
        PlaySound(audioClipRefsSO.playerHurtSound, player.transform.position, volume);
    }

    private void PlayerCombatController_OnParrySuccess(object sender, System.EventArgs e)
    {
        PlayerCombatController player = sender as PlayerCombatController;
        PlaySound(audioClipRefsSO.parrySuccess, player.transform.position, volume);
    }

    private void PlayerMovementController_OnWallJumping(object sender, System.EventArgs e)
    {
        PlayerMovementController player = sender as PlayerMovementController;
        PlaySound(audioClipRefsSO.playerWallJump, player.transform.position, volume);
    }

    private void PlayerMovementController_OnJumping(object sender, System.EventArgs e)
    {
        PlayerMovementController player = sender as PlayerMovementController;
        PlaySound(audioClipRefsSO.playerJump, player.transform.position, volume);
    }

    private void PlayerMovementController_onDashing(object sender, System.EventArgs e)
    {
        PlayerMovementController player = sender as PlayerMovementController;
        PlaySound(audioClipRefsSO.playerDashing, player.transform.position, volume);
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
        
        PlaySound(audioClipRefsSO.playerFootstep, 0.9f * Camera.main.transform.position + 0.1f * position, volume);
    }

    public void SetVolume(float volume)
    {
        this.volume = volume;
    }
}
