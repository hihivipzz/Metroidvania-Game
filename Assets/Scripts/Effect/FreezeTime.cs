using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTime : MonoBehaviour
{
    public void FreezeTimer(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(DoTimeFreeze(duration));

    }

    private IEnumerator DoTimeFreeze(float duration)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }
}
