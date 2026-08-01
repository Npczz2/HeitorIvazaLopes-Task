using UnityEngine;

public class PlayerTrapManager : MonoBehaviour
{
    private PlayerLife _playerLife;

    [Header("Other")]
    [SerializeField] private Transform _respawnPosition;

    private const float _dieHeight = -0.5f;

    void Awake()
    {
        _playerLife = GetComponent<PlayerLife>();
    }

    void Update()
    {
        if(transform.position.y < _dieHeight)
        {
            _playerLife.TakeDamage();
            transform.position = _respawnPosition.position;
        }
    }
}
