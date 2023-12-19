using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/StateData/MoveState")]
public class D_MoveState : ScriptableObject
{
    public string animBoolName = "isWalking";

    public float movementSpeed = 3f;
}
