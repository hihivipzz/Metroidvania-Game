using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerProperty playerProperty { get; private set; }
    private PlayerAnimator playerAnimator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerProperty = GetComponent<PlayerProperty>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerProperty.currentBlood = playerProperty.maxBlood;
        playerProperty.currentHearth = playerProperty.maxHearth;
    }

    private void OnDamage(AttackDetails attackDetail)
    {
        if (playerProperty.currentBlood > 0)
        {
            playerProperty.currentBlood -= attackDetail.damageAmount;
            UIHealthBar.instance.SetValue(playerProperty.currentBlood / (float)playerProperty.maxBlood);
            playerAnimator.HurtAnimation(true);
            //spriteRenderer.GetComponent<FlashEffect>().Flash();
        }

        if (playerProperty.currentBlood <= 0)
        {
            playerProperty.currentBlood = 0;
            playerProperty.isDead = true;
            playerAnimator.DeadAnimation(true);
            HearthLayer.instance.RemoveHeart(playerProperty.currentHearth - 1);
            playerProperty.currentHearth -= 1;
        }
    }

    private void Update()
    {
        //if (playerProperty.currentHearth >= 3)
        //{
        //    AttackDetails attackDetails = new AttackDetails();
        //    attackDetails.position = transform.position;
        //    attackDetails.damageAmount = 1f;
        //    OnDamage(attackDetails);
        //}
    }
}
