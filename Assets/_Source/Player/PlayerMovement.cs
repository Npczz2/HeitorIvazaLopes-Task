using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector2 _moveDir;
    private float _moveSpd = 3f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    //------------------------------------------------------------------

    void FixedUpdate()
    {
        Move();
    }

    //------------------------------------------------------------------

    void Move()
    {
        _rb.linearVelocity = new Vector3(_moveDir.x * _moveSpd, 0, _moveDir.y * _moveSpd);
    }

    //------------------------------------------------------------------

    public void GetMoveInput(InputAction.CallbackContext context)
    {
        _moveDir = context.ReadValue<Vector2>();
    }

}
