using UnityEngine;

public class DroppedItem : MonoBehaviour, IInteractable
{
    public ItemScriptableObject ReferenceItem;
    private PlayerInventory _playerInventory;

    void Awake()
    {
        _playerInventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        _playerInventory.AddItem(ReferenceItem);
        Destroy(gameObject);
    }
}
