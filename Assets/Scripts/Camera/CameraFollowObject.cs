using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;


    [Header("Flip Rotation Stats")]
    [SerializeField] private float _flipRotationTime = 0.5f;

    private Coroutine _turnCoroutine;

    private Player _player;

    private bool _isFacingRight;


    private void Awake()
    {
        _player = _playerTransform.gameObject.GetComponent<Player>();
        _isFacingRight = true;
    
    }


    private void Update()
    {
        // make the cameraFollowObject's position the same as the player's position
        transform.position = _playerTransform.position;
    }

    public void CallTurn()
    {
        //_turnCoroutine = StartCoroutine(FlipYLerp());
        LeanTween.rotateY(gameObject, DetermineEndRotation(), _flipRotationTime).setEaseInOutSine();
    }

    private IEnumerator FlipYLerp()
    {
        float startRotation = transform.localEulerAngles.y;
        float endRotationAmount = DetermineEndRotation();
        float yRotation = 0f;

        float elapsedTime = 0f;
        while(elapsedTime < _flipRotationTime)
        {
            yRotation = Mathf.Lerp(startRotation, endRotationAmount, elapsedTime / _flipRotationTime);
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private float DetermineEndRotation()
    {
        _isFacingRight = !_isFacingRight;
        if(_isFacingRight)
        {
            return 180f;
        }
        else
        {
            return 0f;
        }
    }


}
