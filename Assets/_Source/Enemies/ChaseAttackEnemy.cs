using System.Collections;
using UnityEngine;

public class ChaseAttackEnemy : MonoBehaviour
{
    private Transform _playerTransform;
    private Rigidbody2D _rb;

    private Vector2 _moveDir;
    private float _moveSpd = 1.2f;

    private float _getPositionTimer = 1.25f;
    private int _chancesToHit = 4;

    void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(TargetPlayerCoroutine());
    }

    //------------------------------------------------------------------

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _rb.linearVelocity = _moveDir * _moveSpd;
    }

    //------------------------------------------------------------------

    void SetMoveDir()
    {
        _moveDir = (_playerTransform.position - transform.position).normalized;
    }

    IEnumerator TargetPlayerCoroutine()
    {
        for(int i = 0; i < _chancesToHit; i++)
        {
            SetMoveDir();
            yield return new WaitForSeconds(_getPositionTimer);
        }

        Destroy(gameObject);
    }
}
