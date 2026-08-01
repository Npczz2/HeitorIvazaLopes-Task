using UnityEngine;

public class EnemyHorde : MonoBehaviour
{
    private DungeonManager _dungeonManager;

    void Awake()
    {
        _dungeonManager = FindFirstObjectByType<DungeonManager>();
    }

    void Update()
    {
        if(transform.childCount < 1)
        {
            _dungeonManager.GetHordeDeathReward();
            Destroy(gameObject);
        } 
    }
}
