using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private Player player;
    private PlayerMovementController playerMovementController;
    private float lastFootstepSound;
    private float footstepSoundTime = 0.4f;

    private void Awake()
    {
        player = GetComponent<Player>();
        playerMovementController = GetComponent<PlayerMovementController>();
        lastFootstepSound = 0;
    }

    private void Update()
    {
        if(Time.time> lastFootstepSound + footstepSoundTime && playerMovementController.isGroundRunning)
        {
            SoundManager.Instance.PlayFootstepSound(player.transform.position);
            lastFootstepSound = Time.time;
        }

    }
}
