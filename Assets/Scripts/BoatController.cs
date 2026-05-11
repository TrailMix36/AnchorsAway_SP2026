/*****************************************************************************
// File Name : BoatController.cs
// Author : Simon Bruening-Wright
// Creation Date : 3/26/2026
//
// Brief Description : Controls the boats movement And the menu and inventory
*****************************************************************************/

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BoatController : MonoBehaviour
{
    private float forwardInput;
    private float horizontalInput;
    private InputAction move;
    private InputAction inventory;
    private InputAction menu;
    [SerializeField] private GameObject menuObj;
    [SerializeField] private GameObject invobj;
    [SerializeField] private int speed;
    [SerializeField] private int turnSpeed;
    /// <summary>
    /// Assigns input actions
    /// </summary>
    void Start()
    {
        menu = InputSystem.actions.FindAction("Menu");
        inventory = InputSystem.actions.FindAction("Inventory");
        move = InputSystem.actions.FindAction("Move");
        menu.performed += Menu_performed;
        inventory.performed += Inventory_performed;
        move.performed += Move_Performed;
        move.canceled += Move_Canceled;
    }
    /// <summary>
    /// Opens and closes the menu when you press escape
    /// </summary>
    /// <param name="obj"></param>
    private void Menu_performed(InputAction.CallbackContext obj)
    {
        if(menuObj != null)
        {
            menuObj.SetActive(!menuObj.activeSelf);
        }
        
    }
    /// <summary>
    /// Opens and closes the inventory when you press Tab
    /// </summary>
    /// <param name="obj"></param>
    private void Inventory_performed(InputAction.CallbackContext obj)
    {
        if(invobj != null)
        {
            invobj.SetActive(!invobj.activeSelf);
        }
       
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
    /// <summary>
    /// Checks for if you hit a wall and reloads the scene if you do
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
