using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDungeonMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _spriteRender;

    private Vector2 _moveDir;
    private float _moveSpd = 3f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
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

        _spriteRender.flipX = _moveDir.x <= 0; //Flip to match side
    }
}
