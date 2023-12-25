using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerProperty playerProperty;
    private PlayerAnimator playerAnimator;
    private float blood;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerProperty = GetComponent<PlayerProperty>();
        playerAnimator = GetComponent<PlayerAnimator>();
        blood = playerProperty.maxBlood;
    }

    private void OnDamage(AttackDetails attackDetail)
    {
        if (blood > 0)
        {
            blood -= attackDetail.damageAmount;
            //spriteRenderer.GetComponent<FlashEffect>().Flash();
        }

        if (blood <= 0)
        {
            blood = 0;
            playerAnimator.DeadAnimation(true);
        }
    }

    private void Update()
    {
        //AttackDetails attackDetails = new AttackDetails();
        //attackDetails.position = transform.position;
        //attackDetails.damageAmount = 1f;
        //OnDamage(attackDetails);
    }
}
