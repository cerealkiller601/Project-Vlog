using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    InputAction moveAround = InputSystem.actions.FindAction("Move");
    [SerializeField] float sprintSpeed;

    private void Awake()
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 moveVector;
        moveVector = moveAround.ReadValue<Vector2>();
        Debug.Log(moveVector);
    }

    private void FixedUpdate()
    {
        
    }
}
