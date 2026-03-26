/*****************************************************************************
// File Name : PlayerController.cs
// Author : Simon Bruening-Wright
// Creation Date : 3/26/2026
//
// Brief Description : Controls the player underwater
*****************************************************************************/

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction move;
    private InputAction look;
    private InputAction locked;
    private Vector3 playerMovement;
    private Rigidbody rb;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpValue;
    [SerializeField] private float mouseSensitivity = 150f;

    [SerializeField] private Transform cameraTarget;

    float xRotation = 0f;
    Vector2 lookInput;
    /// <summary>
    /// Assigns each input action and locks the cursor when playing
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        move = InputSystem.actions.FindAction("Move");
        
        look = InputSystem.actions.FindAction("Look");

        locked = InputSystem.actions.FindAction("Sprint");

        move.performed += MovePerformed;
        move.canceled += MoveCanceled;

        

        look.performed += LookPerformed;
        look.canceled += LookCanceled;

        locked.performed += LockedPerformed;

        Cursor.lockState = CursorLockMode.Locked;
    }
    /// <summary>
    /// Checks the cursor lock state and switches it to whatever it isnt currently
    /// </summary>
    /// <param name="obj"></param>
    private void LockedPerformed(InputAction.CallbackContext obj)
    {
       if(Cursor.lockState == CursorLockMode.Locked)
       {
            UnLockCursor();
       }
        else
        {
            LockCursor();
        }
    }

    /// <summary>
    /// assigns the vector 2 from the look action to the look input variable
    /// </summary>
    /// <param name="obj"></param>
    private void LookPerformed(InputAction.CallbackContext obj)
    {
        lookInput = obj.ReadValue<Vector2>();
    }
    /// <summary>
    /// clears the look input
    /// </summary>
    /// <param name="obj"></param>
    private void LookCanceled(InputAction.CallbackContext obj)
    {
        lookInput = Vector2.zero;
    }
    
    /// <summary>
    /// clears the player movement
    /// </summary>
    /// <param name="obj"></param>
    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        playerMovement = Vector3.zero;
    }
    /// <summary>
    /// sets the player movement when the move inputs are used
    /// </summary>
    /// <param name="obj"></param>
    private void MovePerformed(InputAction.CallbackContext obj)
    {
        playerMovement.x = obj.ReadValue<Vector2>().x * playerSpeed;
        playerMovement.z = obj.ReadValue<Vector2>().y * playerSpeed;
    }
    /// <summary>
    /// constantly calls the MouseLook function if the cursor is locked
    /// </summary>
    void Update()
    {
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            MouseLook();
        }
        
    }
    /// <summary>
    /// Makes the player move
    /// </summary>
    void FixedUpdate()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        Vector3 move = right * playerMovement.x + forward * playerMovement.z;
        move.y = rb.linearVelocity.y;
        rb.linearVelocity = move;
    }

    /// <summary>
    /// Moves the camera when you move your mouse
    /// </summary>
    private void MouseLook()
    {
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraTarget.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, mouseX, 0f));

    }
    /// <summary>
    /// Prevents memory leaks when restarting the game
    /// </summary>
    private void OnDestroy()
    {
        if (move != null)
        {
            move.performed -= MovePerformed;
            move.canceled -= MoveCanceled;
        }
        
        
        if(locked != null)
        {
            locked.performed -= LockedPerformed;
        }
        
        if(look != null)
        {
            look.performed -= LookPerformed;
            look.canceled -= LookCanceled;
        }
        
    }
    /// <summary>
    /// Locks the cursor
    /// </summary>
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    /// <summary>
    /// Unlocks the cursor
    /// </summary>
    private void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
