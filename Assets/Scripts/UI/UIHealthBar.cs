using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar Instance { get; private set; }
    public Slider slider;

    [SerializeField]
    private Image mask;
    float originalSize;
    [SerializeField]
    Player player;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        player.OnPlayerHealthChange += Player_OnPlayerHealthChange;
        SetValue(1);
    }

    private void Player_OnPlayerHealthChange(object sender, System.EventArgs e)
    {
        SetValue(player.currentHealth/player.GetData().maxHealth);
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
