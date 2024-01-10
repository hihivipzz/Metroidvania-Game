using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    public static ScreenShaker Instance { get; private set; }

    private CinemachineVirtualCamera _virutualCamera;
    private CinemachineBasicMultiChannelPerlin _cameraNoise;

    private void Awake()
    {
        Instance= this;
    }
    private void Start()
    {
        _virutualCamera= FindObjectOfType<CinemachineVirtualCamera>();
        if(_virutualCamera != null )
        {
            _cameraNoise = _virutualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        else
        {
            Debug.Log("No virtual camera");
        }
       
    }

    public void BasicShake(float intensity, float duration)
    {
        StartCoroutine(DoBasicShake(intensity, duration));
    }

    private IEnumerator DoBasicShake(float intensity,float duration)
    {
        if (_virutualCamera != null)
        {
            _cameraNoise = _virutualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
        if (_cameraNoise != null)
        {
            _cameraNoise.m_AmplitudeGain = intensity;
            yield return new WaitForSeconds(duration);
            _cameraNoise.m_AmplitudeGain = 0f;
        }
        else
        {
            Debug.LogError("CinemachineBasicMultiChannelPerlin not found. Screen shaking will not work.");
        }
    }
}
