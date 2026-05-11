/*****************************************************************************
// File Name : SpearController.cs
// Author : Simon Bruening-Wright
// Creation Date : 4/21/2026
//
// Brief Description : Controls the spear underwater
*****************************************************************************/

using UnityEngine;
using UnityEngine.InputSystem;

public class SpearController : MonoBehaviour
{
    private InputAction spear;
    private Animator animator;
    
    /// <summary>
    /// Assigns input actions and components
    /// </summary>
    void Start()
    {
         
        animator = GetComponent<Animator>();
        spear = InputSystem.actions.FindAction("Spear");
        spear.performed += Spear_performed;
    }
    /// <summary>
    /// Activates the spear animation on click
    /// </summary>
    /// <param name="obj"></param>
    private void Spear_performed(InputAction.CallbackContext obj)
    {
        if(animator != null)
        {
            animator.SetTrigger("Spear");
        }
        
    }
    /// <summary>
    /// Deactivates fish when they are speared and calls the AddFish function from the GameManager
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            GameManager.Instance.AddFish();
            collision.gameObject.SetActive(false);
        }
    }
}
