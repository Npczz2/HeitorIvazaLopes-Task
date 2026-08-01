using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private PlayerInput _playerInput;

    [Header("Interface")]
    [SerializeField] private GameObject _pauseInterface;

    public void Pause(bool pause)
    {
        _pauseInterface.SetActive(pause);
        Time.timeScale = pause ? 0f : 1f;
        _playerInput.SwitchCurrentActionMap(pause ? "Pause" : "Player");
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    //------------------------------------------------------------------

    public void GetPauseInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Pause(true);
        }
    }

    public void GetUnpauseInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Pause(false);
        }
    }
}
