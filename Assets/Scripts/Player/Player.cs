using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 7f;
    [SerializeField] private GameInput gameInput;

    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        //Handle Interact
    }

    private void Update()
    {
        MovementHanlder();
    }

    private void MovementHanlder()
    {
        Vector2 inputVector = gameInput.GetMovementNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, 0f);
        transform.position += moveDir * speed * Time.deltaTime;
    }
}
