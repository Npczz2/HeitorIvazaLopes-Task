using TMPro;
using UnityEngine;

public class DayInterfaceManager : MonoBehaviour
{
    [Header("Interface elements")]
    [SerializeField] private TMP_Text _dailyQuota;
    [SerializeField] private TMP_Text _dayCount;
    [SerializeField] private GameObject _endNightButton;
    [SerializeField] private TMP_Text _objective;

    public void RenderDailyQuota(int dailyQuota)
    {
        _dailyQuota.text = "Daily quota: $" + dailyQuota;
    }

    public void RenderDayCount(int day, bool night)
    {
        _dayCount.text = (night ? "Night " : "Day ") + day;
    }

    public void ActivateEndNightButton(bool activate)
    {
        _endNightButton.SetActive(activate);
    }

    public void SetObjective(bool night)
    {
        if(night)
        {
            _objective.text = "Objective: Sell your items at the city's shop.";
        }
        else
        {
            _objective.text = "Objective: Go to the door and enter the dungeon.";
        }
    }
}
