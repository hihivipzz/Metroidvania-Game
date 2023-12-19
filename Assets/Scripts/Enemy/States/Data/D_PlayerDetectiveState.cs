using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newPlayerDetectiveStateData", menuName = "Data/StateData/PlayerDetectiveState")]
public class D_PlayerDetectiveState : ScriptableObject
{
    public string animBoolName = "playerDetected";

    public float longRangeActionTime = 1f;
}
