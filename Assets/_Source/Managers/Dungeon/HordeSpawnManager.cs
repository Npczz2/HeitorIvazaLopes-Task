using System.Collections.Generic;
using UnityEngine;

public class HordeSpawnManager : MonoBehaviour
{
    [Header("Attack prefabs")]
    [SerializeField] private List<GameObject> _enemyAttackPrefabs;

    private DungeonManager _dungeonManager;

    private float _spawnTimer;
    private float _spawnMaxTimer = 4f;

    void Awake()
    {
        _dungeonManager = GetComponent<DungeonManager>();
    }

    void Update()
    {
        if(_dungeonManager.CombatStarted) SpawnAttackCounter();
    }

    //------------------------------------------------------------------

    void SpawnAttackCounter()
    {
        _spawnTimer += Time.deltaTime;
        if(_spawnTimer >= _spawnMaxTimer)
        {
            _spawnTimer = 0;
            SpawnAttack();

            if(_spawnMaxTimer > 2f) _spawnMaxTimer *= 0.9f;
        }
    }

    void SpawnAttack()
    {
        int r = Random.Range(0, _enemyAttackPrefabs.Count);
        Instantiate(_enemyAttackPrefabs[r], new Vector3(0,0,0), Quaternion.identity);
    }
}
