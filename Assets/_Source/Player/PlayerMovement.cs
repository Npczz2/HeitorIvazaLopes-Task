using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector2 _moveDir;

    private float _moveSpd = 3f;
    private float _gravityMultiplier = 3.5f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        Move();
        IncreaseGravity();
    }

    //------------------------------------------------------------------

    void Move()
    {
        _rb.linearVelocity = new Vector3(_moveDir.x * _moveSpd, 0, _moveDir.y * _moveSpd);
    }

    void IncreaseGravity()
    {
        _rb.AddForce(Physics.gravity * (_gravityMultiplier - 1), ForceMode.Acceleration); //-1 represent the gravity itself
    }

    //------------------------------------------------------------------

    public void GetMoveInput(InputAction.CallbackContext context)
    {
        _moveDir = context.ReadValue<Vector2>();
    }

}
