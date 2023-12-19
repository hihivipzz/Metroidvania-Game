using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newLookForPlayerStateData", menuName = "Data/StateData/LookForPlayerState")]
public class D_LookForPlayerState : ScriptableObject
{
    public string animBoolName = "isLookingForPlayer";

    public int amountOfTurn = 2;
    public float timeBetweenTurn = 0.75f;
}
