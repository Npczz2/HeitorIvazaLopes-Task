using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopManager : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerInterfaceManager _playerInterfaceManager;
    [SerializeField] private ShopInterfaceManager _shopInterfaceManager;

    private List<int> _selectedItemsIndex = new List<int>();

    public void OpenShop()
    {
        _shopInterfaceManager.OpenShop();
        _playerInput.SwitchCurrentActionMap("UI");

        ClearSelectedItems();
    }

    public void CloseShop()
    {
        _shopInterfaceManager.CloseShop();
        _playerInput.SwitchCurrentActionMap("Player");
    }

    //------------------------------------------------------------------

    public void SelectItem(int index)
    {
        if(_playerInventory.Items[index] == null) return;

        if(!CheckItemSelected(index))
        {
            _selectedItemsIndex.Add(index);
            _shopInterfaceManager.SelectItem(true, index);

            _shopInterfaceManager.RenderTotalPrice(CalculateTotalPrice());
        }
    }

    public void SellSelectedItems()
    {
        if(_selectedItemsIndex.Count < 1) return;
        
        int totalGold = CalculateTotalPrice();

        for(int i = 0; i < _selectedItemsIndex.Count; i++)
        {
            _playerInventory.Items[_selectedItemsIndex[i]] = null;
        }

        PlayerScenePersistentData.Instance.AddGold(totalGold);
        _playerInterfaceManager.RenderGold();

        _shopInterfaceManager.RenderInventory();
        _shopInterfaceManager.ClearAllSelections();
    }

    //------------------------------------------------------------------

    int CalculateTotalPrice()
    {
        int totalGold = 0;

        for(int i = 0; i < _selectedItemsIndex.Count; i++)
        {
            totalGold += _playerInventory.Items[_selectedItemsIndex[i]].Item.ItemPrice * _playerInventory.Items[_selectedItemsIndex[i]].ItemQuantity;
        }

        return totalGold;
    }

    //------------------------------------------------------------------

    bool CheckItemSelected(int index)
    {
        if(_selectedItemsIndex.Count < 1) return false;

        for(int i = 0; i < _selectedItemsIndex.Count; i++)
        {
            if(_selectedItemsIndex[i] == index)
            {
                _shopInterfaceManager.SelectItem(false, _selectedItemsIndex[i]);
                _selectedItemsIndex.RemoveAt(i);

                _shopInterfaceManager.RenderTotalPrice(CalculateTotalPrice());
                return true;
            } 
        }

        return false;
    }

    void ClearSelectedItems()
    {
        _selectedItemsIndex.Clear();
        _shopInterfaceManager.ClearAllSelections();
        _shopInterfaceManager.RenderTotalPrice(0);
    }

    //------------------------------------------------------------------

    public void GetCloseShopInput(InputAction.CallbackContext context)
    {
        if(context.performed) CloseShop();
        
    }
}
