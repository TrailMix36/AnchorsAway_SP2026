using UnityEngine;
using UnityEngine.InputSystem;

public class SpearController : MonoBehaviour
{
    private InputAction spear;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        spear = InputSystem.actions.FindAction("Spear");
        spear.performed += Spear_performed;
    }

    private void Spear_performed(InputAction.CallbackContext obj)
    {
        animator.SetTrigger("Spear");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
