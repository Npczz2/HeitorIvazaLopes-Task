using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private InventoryInterfaceManager _interfaceManager;
    [SerializeField] private PlayerInput _playerInput;

    [Header("Other")]
    [SerializeField] private GameObject _defaultItemPrefab;

    public QuantifiedItem[] Items {get; private set;}

    [HideInInspector]
    public int SelectedItemIndex = -1;

    private float _dropRange = 0.5f;

    void Awake()
    {
        Items = new QuantifiedItem[20];
    }

    //------------------------------------------------------------------

    public void AddItem(ItemScriptableObject newItem)
    {
        for(int i = 0; i < Items.Length; i++)
        {
            if(Items[i] != null)
            {
                if(Items[i].Item.ItemID == newItem.ItemID)
                {
                    Items[i].ItemQuantity++;
                    break;
                }
            }
            else
            {
                Items[i] = new QuantifiedItem(newItem, 1);
                break;
            }
        }
    }

    public void DropSelectedItem()
    {
        if(Items[SelectedItemIndex] == null) return;

        GameObject itemToDrop = _defaultItemPrefab;
        itemToDrop.GetComponent<SpriteRenderer>().sprite = Items[SelectedItemIndex].Item.ItemSprite;
        itemToDrop.GetComponent<DroppedItem>().ReferenceItem = Items[SelectedItemIndex].Item;

        Instantiate(itemToDrop, transform.position + new Vector3(0, 0, -_dropRange), Quaternion.identity);

        Items[SelectedItemIndex].ItemQuantity--;

        if(Items[SelectedItemIndex].ItemQuantity <= 0)
        {
            Items[SelectedItemIndex] = null;
            _interfaceManager.UnselectItems();
        }

        _interfaceManager.RenderInventory();
    }

    //------------------------------------------------------------------

    public void SwapInventorySlots(int fromSlotIndex, int toSlotIndex)
    {
        if(Items[fromSlotIndex] == null || fromSlotIndex == toSlotIndex) return;

        QuantifiedItem swappedItem = Items[toSlotIndex];
        Items[toSlotIndex] = Items[fromSlotIndex];
        Items[fromSlotIndex] = swappedItem;

        _interfaceManager.UnselectItems();
        _interfaceManager.RenderInventory();
    }

    //------------------------------------------------------------------

    public void LoadSavedItems(QuantifiedItem[] items)
    {
        Items = items;
        Debug.Log("Items loaded.");
    }

    //------------------------------------------------------------------

    public void GetOpenInventoryInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _interfaceManager.OpenInventory();
            _playerInput.SwitchCurrentActionMap("UI");
        } 
    }

    public void GetCloseInventoryInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _interfaceManager.CloseInventory();
            _playerInput.SwitchCurrentActionMap("Player");
        } 
    }
}
