using UnityEngine;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private PlayerInput _playerInput;

    [Header("Interface")]
    [SerializeField] private DialogInterfaceManager _dialogInterfaceManager;

    private DialogScriptableObject _currentDialog;
    private int _curDialogLine = 0;

    public void StartDialog(DialogScriptableObject dialog)
    {
        if(dialog.DialogLines.Count < 1) return;

        _currentDialog = dialog;
        _curDialogLine = 0;

        _dialogInterfaceManager.StartDialogInterface();
        _dialogInterfaceManager.PrintLine(dialog.DialogLines[_curDialogLine].CharacterName, dialog.DialogLines[_curDialogLine].Line);

        _playerInput.SwitchCurrentActionMap("UI");
    }

    void EndDialog()
    {
        _dialogInterfaceManager.EndDialogInterface();
        _currentDialog = null;

        _playerInput.SwitchCurrentActionMap("Player");
    }

    //------------------------------------------------------------------

    void PassDialogLine()
    {
        _curDialogLine++;

        if(_curDialogLine >= _currentDialog.DialogLines.Count)
        {
            EndDialog();
            return;
        } 

        _dialogInterfaceManager.PrintLine(_currentDialog.DialogLines[_curDialogLine].CharacterName, _currentDialog.DialogLines[_curDialogLine].Line);
    }

    //------------------------------------------------------------------

    public void GetPassLineInput(InputAction.CallbackContext context)
    {
        if(context.performed && _currentDialog != null) PassDialogLine();
    }
}
