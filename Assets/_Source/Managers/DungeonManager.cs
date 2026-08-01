using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private DungeonInterfaceManager _dungeonInterfaceManager;

    private float _dungeonTimer;

    void Update()
    {
        CountDungeonTimer();
    }

    //------------------------------------------------------------------

    void CountDungeonTimer()
    {
        _dungeonTimer += Time.deltaTime;
        _dungeonInterfaceManager.FormatDungeonTime(Mathf.RoundToInt(_dungeonTimer));
    }
}
