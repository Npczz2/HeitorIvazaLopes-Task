using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private DayInterfaceManager _dayInterfaceManager;
    [SerializeField] private PlayerInterfaceManager _playerInterfaceManager;

    [Header("Night Objects")]
    [SerializeField] private List<GameObject> _nightObjectList = new List<GameObject>();

    private const int _baseQuota = 10;// Base 200
    private int _dailyQuota;

    void Start()
    {
        if(PlayerScenePersistentData.Instance.IsDayTime)
        {
            StartDay();
        }
        else
        {
            StartNight();
        }
        
    }

    //------------------------------------------------------------------

    void StartDay()
    {
        PlayerScenePersistentData.Instance.IsDayTime = true;
        
        CalculateDailyQuota();
        _dayInterfaceManager.RenderDayCount(PlayerScenePersistentData.Instance.Day, false);

        _dayInterfaceManager.ActivateEndNightButton(false);
        EnableNightObjects(false);
    }

    public void EndNight()
    {
        if(PlayerScenePersistentData.Instance.Gold >= _dailyQuota)
        {
            PlayerScenePersistentData.Instance.SetGold(PlayerScenePersistentData.Instance.Gold - _dailyQuota);
            _playerInterfaceManager.RenderGold();

            PlayerScenePersistentData.Instance.Day++;
            StartDay();

            if(PlayerScenePersistentData.Instance.Day >= 4)
            {
                _gameManager.GameWin();
            }
        }
        else
        {
            _gameManager.GameOver();
        }
    }

    //------------------------------------------------------------------

    void StartNight()
    {
        CalculateDailyQuota();
        _dayInterfaceManager.RenderDayCount(PlayerScenePersistentData.Instance.Day, true);

        _dayInterfaceManager.ActivateEndNightButton(true);
        EnableNightObjects(true);
    }

    void EnableNightObjects(bool enable)
    {
        for(int i = 0; i < _nightObjectList.Count; i++)
        {
            _nightObjectList[i].SetActive(enable);
        }
    }

    //------------------------------------------------------------------

    void CalculateDailyQuota()
    {
        _dailyQuota = _baseQuota * PlayerScenePersistentData.Instance.Day;
        _dayInterfaceManager.RenderDailyQuota(_dailyQuota);
    }
}
