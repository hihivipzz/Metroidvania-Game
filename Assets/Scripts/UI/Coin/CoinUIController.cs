using TMPro;
using UnityEngine;

public class CoinUIController : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public Player player;
    public void SetCoin(int coin)
    {
        coinText.text = coin.ToString();
    }

    void Update()
    {
        coinText.text = player.playerProperty.totalCoin.ToString();
    }
}
