using UnityEngine;
using UnityEngine.InputSystem;
public class BoatController : MonoBehaviour
{
    private float forwardInput;
    private float horizontalInput;
    private InputAction move;
    [SerializeField] private int speed;
    [SerializeField] private int turnSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        move.performed += Move_Performed;
        move.canceled += Move_Canceled;
    }

    private void Move_Canceled(InputAction.CallbackContext obj)
    {
        forwardInput = 0f;
        horizontalInput = 0f;
    }

    private void Move_Performed(InputAction.CallbackContext obj)
    {
        forwardInput = obj.ReadValue<Vector2>().y;
        horizontalInput = obj.ReadValue<Vector2>().x;
    }

    // Update is called once per frame
    void Update()
    {


        //transform.Translate(0, 0, 1);   //Moves vehicle forward

        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);

    }
}
