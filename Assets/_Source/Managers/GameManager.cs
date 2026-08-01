using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] private GameObject _gameOverInterface;

    public void GameOver()
    {
        Time.timeScale = 0f;
        _gameOverInterface.SetActive(true);
    }

    public void RestartGame()
    {
        PlayerDataManager.Instance.ClearSavedData();
        SceneManager.LoadScene("City");
        Time.timeScale = 1f;
    }
}
