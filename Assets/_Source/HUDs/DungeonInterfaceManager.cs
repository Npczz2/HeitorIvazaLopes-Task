using TMPro;
using UnityEngine;

public class DungeonInterfaceManager : MonoBehaviour
{
    [Header("Interface elements")]
    [SerializeField] private TMP_Text _dungeonTimer;

    public void FormatDungeonTime(int time)
    {
        int seconds = time % 60;
        int minutes = time / 60;

        _dungeonTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
