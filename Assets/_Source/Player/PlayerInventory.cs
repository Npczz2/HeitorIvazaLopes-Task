using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private InventoryInterfaceManager _interfaceManager;
    [SerializeField] private PlayerInput _playerInput;
    public QuantifiedItem[] Items {get; private set;}

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
