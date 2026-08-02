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

        if(_enterDungeon)
        {
            SceneManager.LoadScene("Dungeon");
        }
        else
        {
            PlayerScenePersistentData.Instance.IsDayTime = false;
            SceneManager.LoadScene("City");
        }
    }
}
