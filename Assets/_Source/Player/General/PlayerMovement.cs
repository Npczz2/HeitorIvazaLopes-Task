using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _anim;
    private SpriteRenderer _spriteRender;

    private Vector2 _moveDir;

    private float _moveSpd = 2f;
    private float _gravityMultiplier = 3.5f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckPlayerMovement();
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
        _rb.AddForce(Physics.gravity * (_gravityMultiplier - 1), ForceMode.Acceleration);
    }

    //------------------------------------------------------------------

    void CheckPlayerMovement()
    {
        if(_moveDir == Vector2.zero)
        {
            _anim.SetBool("Walking", false);
        }
        else
        {
            _anim.SetBool("Walking", true);
            _anim.SetFloat("Vertical", _moveDir.y);
        }

        _spriteRender.flipX = _moveDir.x >= 0; //Flip to match side
    }

    //------------------------------------------------------------------

    public void GetMoveInput(InputAction.CallbackContext context)
    {
        _moveDir = context.ReadValue<Vector2>();
    }

}
