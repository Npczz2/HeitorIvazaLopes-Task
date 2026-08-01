using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private DungeonInterfaceManager _dungeonInterfaceManager;
    private GameManager _gameManager;

    private float _dungeonTimer = 120;

    void Awake()
    {
        _gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        CountDungeonTimer();
    }

    //------------------------------------------------------------------

    void CountDungeonTimer()
    {
        _dungeonTimer -= Time.deltaTime;
        _dungeonInterfaceManager.FormatDungeonTime(Mathf.RoundToInt(_dungeonTimer));

        if(_dungeonTimer <= 0)
        {
            _gameManager.GameOver();
            _dungeonTimer = 120;
        }
    }
}
