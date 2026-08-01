using System.Collections;
using UnityEngine;

public class ChaseAttackEnemy : MonoBehaviour
{
    private Transform _playerTransform;
    private Rigidbody2D _rb;

    private Vector2 _moveDir;
    private float _moveSpd = 2f;

    private float _getPositionTimer = 1f;
    private int _chancesToHit = 5;

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
        Debug.Log("Pegou a posição");
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
