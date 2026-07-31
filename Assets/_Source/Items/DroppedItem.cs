using UnityEngine;

public class DroppedItem : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemScriptableObject _referenceItem;
    private PlayerInventory _playerInventory;

    void Awake()
    {
        _playerInventory = FindFirstObjectByType<PlayerInventory>(); //Fix?
    }

    public void Interact()
    {
        _playerInventory.AddItem(_referenceItem);
        Destroy(gameObject); //Replace with collect item logic
    }
}
