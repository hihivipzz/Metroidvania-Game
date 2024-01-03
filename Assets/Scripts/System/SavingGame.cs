using System.IO;
using UnityEngine;

public class SavingGame
{
    public void SavePlayerDataJson(GameObject player)
    {
        string path = Path.Combine(Application.persistentDataPath, "player.json");
        FileStream file = File.Create(path);

        Player playerComponent = player.GetComponent<Player>();
        PlayerData data = new PlayerData(playerComponent.playerProperty.currentBlood, playerComponent.transform.position);

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data.ToJson());
        file.Write(bytes, 0, bytes.Length);

        file.Close();
    }
}
