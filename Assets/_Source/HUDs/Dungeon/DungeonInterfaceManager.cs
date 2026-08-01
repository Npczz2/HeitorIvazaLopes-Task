using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DungeonInterfaceManager : MonoBehaviour
{
    [Header("Interface elements")]
    [SerializeField] private TMP_Text _dungeonTimer;
    [SerializeField] private List<TMP_Text> _obtainedItemsCount;

    public void FormatDungeonTime(int time)
    {
        int seconds = time % 60;
        int minutes = time / 60;

        _dungeonTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddItemCounter(int index, int count)
    {
        _obtainedItemsCount[index].text = "x" + count;
    }
}
