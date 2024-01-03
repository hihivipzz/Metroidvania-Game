using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public float health;
    public float[] positon;

    public PlayerData(float health, Vector2 positon)
    {
        this.health = health;
        this.positon = new float[2];
        positon[0] = positon.x;
        positon[1] = positon.y;
    }

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
