using TMPro;
using UnityEngine;

public class DialogInterfaceManager : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] private GameObject _dialogInterface;
    [SerializeField] private TMP_Text _dialogName;
    [SerializeField] private TMP_Text _dialogText;

    public void StartDialogInterface()
    {
        _dialogInterface.SetActive(true);
    }

    public void EndDialogInterface()
    {
        _dialogInterface.SetActive(false);
    }

    public void PrintLine(string lineName, string lineText)
    {
        _dialogName.text = lineName;
        _dialogText.text = lineText;
    }
}
