using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    private Transform _playerTransform;
    private Rigidbody _rb;

    private Vector3 _moveDir;
    private float _moveSpd = 0.75f;

    void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        SetDirection();
        _rb.linearVelocity = _moveDir * _moveSpd;
    }

    void SetDirection()
    {
        _moveDir = (_playerTransform.position - transform.position).normalized;
    }
}
