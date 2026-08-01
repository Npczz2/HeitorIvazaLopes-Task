using UnityEngine;

public class DroppedItem : MonoBehaviour, IInteractable
{
    public ItemScriptableObject ReferenceItem;
    private PlayerInventory _playerInventory;

    void Awake()
    {
        _playerInventory = FindFirstObjectByType<PlayerInventory>(); //Fix?
    }

    public void Interact()
    {
        _playerInventory.AddItem(ReferenceItem);
        Destroy(gameObject); //Replace with collect item logic
    }
}
