using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDungeonMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Vector2 _moveDir;
    private float _moveSpd = 3f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    //------------------------------------------------------------------

    void Move()
    {
        _rb.linearVelocity = _moveDir * _moveSpd;
    }

    public void GetMoveInput(InputAction.CallbackContext context)
    {
        _moveDir = context.ReadValue<Vector2>();
    }
}
