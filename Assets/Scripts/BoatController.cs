/*****************************************************************************
// File Name : BoatController.cs
// Author : Simon Bruening-Wright
// Creation Date : 3/26/2026
//
// Brief Description : Controls the boats movement
*****************************************************************************/

using UnityEngine;
using UnityEngine.InputSystem;

public class BoatController : MonoBehaviour
{
    private float forwardInput;
    private float horizontalInput;
    private InputAction move;
    [SerializeField] private int speed;
    [SerializeField] private int turnSpeed;
    /// <summary>
    /// Assigns input actions
    /// </summary>
    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        move.performed += Move_Performed;
        move.canceled += Move_Canceled;
    }
    /// <summary>
    /// sets the horizontal and forward input to 0 when not pressing a move key
    /// </summary>
    /// <param name="obj"></param>
    private void Move_Canceled(InputAction.CallbackContext obj)
    {
        forwardInput = 0f;
        horizontalInput = 0f;
    }
    /// <summary>
    /// sets the horizontal and forward input when pressing a move key
    /// </summary>
    /// <param name="obj"></param>
    private void Move_Performed(InputAction.CallbackContext obj)
    {
        forwardInput = obj.ReadValue<Vector2>().y;
        horizontalInput = obj.ReadValue<Vector2>().x;
    }

    /// <summary>
    /// Moves and rotates the boat each frame based on the horizontal and forward input
    /// </summary>
    void Update()
    {
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);

    }
}
