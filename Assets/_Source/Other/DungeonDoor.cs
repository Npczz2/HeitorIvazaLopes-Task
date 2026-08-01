using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonDoor : MonoBehaviour, IInteractable
{
    [Header("External scripts")]
    [SerializeField] private PlayerInventory _playerInventory;

    [Header("Other")]
    [SerializeField] private bool _enterDungeon = true;
    public void Interact()
    {
        _playerInventory.StoreSceneItems();
        SceneManager.LoadScene(_enterDungeon ? "Dungeon" : "City");
    }
}
