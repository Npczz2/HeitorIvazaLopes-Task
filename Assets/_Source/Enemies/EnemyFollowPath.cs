using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPath : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetPositions;
    private Rigidbody _rb;
    
    private int _currentTargetPosition = 0;
    private float _moveSpd = 2f;
    private Vector3 _moveDir;

    private const float _approachDistance = 0.2f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(_targetPositions.Count > 0) WalkToTarget();
    }

    //------------------------------------------------------------------

    void WalkToTarget()
    {
        SetDirection(_targetPositions[_currentTargetPosition].position);
        _rb.linearVelocity = _moveDir * _moveSpd;

        if(Vector3.Distance(transform.position, _targetPositions[_currentTargetPosition].position) <= _approachDistance)
        {
            _currentTargetPosition++;
            if(_currentTargetPosition >= _targetPositions.Count)
            {
                _currentTargetPosition = 0;
            }
        }
    }

    //------------------------------------------------------------------

    void SetDirection(Vector3 target)
    {
        _moveDir = (target - transform.position).normalized;
    }
}
