using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Pages")]
    [SerializeField] private GameObject _mainPage;
    [SerializeField] private GameObject _creditsPage;

    public void StartGame()
    {
        SceneManager.LoadScene("City");
    }

    public void OpenCredits()
    {
        CloseAllPages();
        _creditsPage.SetActive(true);
    }

    public void CloseCredits()
    {
        CloseAllPages();
        _mainPage.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //------------------------------------------------------------------

    void CloseAllPages()
    {
        _mainPage.SetActive(false);
        _creditsPage.SetActive(false);
    }
}
