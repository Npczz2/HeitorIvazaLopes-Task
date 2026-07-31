using UnityEngine;

public class FriendlyNPC : MonoBehaviour, IInteractable
{
    [Header("External scripts")]
    [SerializeField] private DialogManager _dialogManager;

    [Header("Other")]
    [SerializeField] private DialogScriptableObject _npcDialog;
    public void Interact()
    {
        _dialogManager.StartDialog(_npcDialog);
    }
}
