using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] private GameObject _gameOverInterface;
    [SerializeField] private GameObject _gameWinInterface;

    public void GameOver()
    {
        Time.timeScale = 0f;
        _gameOverInterface.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        PlayerDataManager.Instance.ClearSavedData();

        ResetStats();

        SceneManager.LoadScene("City");
    }

    //------------------------------------------------------------------

    public void GameWin()
    {
        Time.timeScale = 0f;
        _gameWinInterface.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        ResetStats();
        SceneManager.LoadScene("MainMenu");
    }

    void ResetStats()
    {
        PlayerScenePersistentData.Instance.ClearStoredItems();
        PlayerScenePersistentData.Instance.SetGold(0);
        PlayerScenePersistentData.Instance.Day = 1;
    }
}
