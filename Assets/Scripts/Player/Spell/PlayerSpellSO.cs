using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerSpellData", order = 1)]
public class PlayerSpellSO : ScriptableObject
{
    public GameObject projectile;
    public float ProjectileDame = 2f;
    public float Projectilespeed = 20f;
    public float travelTime = 3f;
}
