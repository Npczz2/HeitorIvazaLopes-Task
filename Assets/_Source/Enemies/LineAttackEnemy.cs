using UnityEngine;

public class LineAttackEnemy : MonoBehaviour
{
    private Rigidbody2D _rb;

    private float _moveSpd = 1.5f;
    private Vector2 _moveDir;

    private enum TargetDirection {Left, Right, Up, Down}
    [SerializeField] private TargetDirection _curTargetDirection;
    private Vector2 _targetPosition;
    private const float _maxTargetDistance = 4f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        SetTargetPosition();
        _moveDir = (_targetPosition - new Vector2(transform.position.x, transform.position.y)).normalized;
    }

    void FixedUpdate()
    {
        Move();
    }

    //------------------------------------------------------------------

    void Move()
    {
        _rb.linearVelocity = _moveDir * _moveSpd;
        CheckArrival();
    }

    void CheckArrival()
    {
        if(Vector2.Distance(transform.position, _targetPosition) <= 0.1f)
        {
            Destroy(gameObject);
        }
    }

    //------------------------------------------------------------------

    void SetTargetPosition()
    {
        switch(_curTargetDirection)
        {
            case TargetDirection.Left:
                _targetPosition = new Vector2(transform.position.x - _maxTargetDistance, transform.position.y);
                break;

            case TargetDirection.Right:
                _targetPosition = new Vector2(transform.position.x + _maxTargetDistance, transform.position.y);
                break;

            case TargetDirection.Up:
                _targetPosition = new Vector2(transform.position.x, transform.position.y + _maxTargetDistance);
                break;

            case TargetDirection.Down:
                _targetPosition = new Vector2(transform.position.x, transform.position.y - _maxTargetDistance);
                break;
        }
    }
}
