using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 lookDirection = Vector2.zero;
    private Vector2 moveDirection = Vector2.zero;
    private bool interactPressed = false;
    private bool jumpPressed = false;
    private bool nextPressed = false;
    private bool submitPressed = false;

    private static InputManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene");
        }
        instance = this;
    }
    public static InputManager GetInstance()
    {
        return instance;
    }
    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }
    public void LookPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            lookDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            lookDirection = context.ReadValue<Vector2>();
        }
    }
    public void InteractPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }
    public void JumpPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpPressed = true;
        }
        else if (context.canceled)
        {
            jumpPressed = false;
        }
    }
    public void NextPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            nextPressed = true;
        }
        else if (context.canceled)
        {
            nextPressed = false;
        }
    }
    public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        }
    }
    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }
    public Vector2 GetLookDirection()
    {
        return lookDirection;
    }
    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }
    public bool GetJumpPressed()
    {
        bool result = jumpPressed;
        jumpPressed = false;
        return result;
    }
    public bool GetNextPressed()
    {
        bool result = nextPressed;
        nextPressed = false;
        return result;
    }

    public bool GetSubmitPressed()
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }

}
