using TMPro;
using UnityEngine;

public class CoinUIController : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public Player player;

    private void Start()
    {
        UpdateText();
        player.OnPlayerCoinChange += Player_OnPlayerCoinChange;
    }
    public void SetCoin(int coin)
    {
        coinText.text = coin.ToString();
    }

    private void Player_OnPlayerCoinChange(object sender, System.EventArgs e)
    {
        UpdateText();
    }

    void UpdateText()
    {
       
        coinText.text = player.coinNumber.ToString();
    }
}
