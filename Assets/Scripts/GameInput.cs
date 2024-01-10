using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnJumpAction;
    public event EventHandler OnJumpCancel;
    public event EventHandler onDashAction;
    public event EventHandler OnGuardStart;
    public event EventHandler OnGuardCancel;
    public event EventHandler OnSpellAction;

    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.Jump.started += Jump_performed;
        playerInputActions.Player.Jump.canceled += Jump_canceled;
        playerInputActions.Player.Dashing.performed += Dashing_performed;
        playerInputActions.Player.Guard.started += Guard_started;
        playerInputActions.Player.Guard.canceled += Guard_canceled;
        playerInputActions.Player.Spell.performed += Spell_performed;
    }

    private void Spell_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSpellAction?.Invoke(this, EventArgs.Empty);
    }

    private void Guard_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnGuardCancel?.Invoke(this, EventArgs.Empty);
    }

    private void Guard_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnGuardStart?.Invoke(this, EventArgs.Empty);
    }

    private void Dashing_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        onDashAction?.Invoke(this, EventArgs.Empty);
    }

    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJumpCancel?.Invoke(this, EventArgs.Empty);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJumpAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
