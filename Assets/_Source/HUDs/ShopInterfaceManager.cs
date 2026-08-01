using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopInterfaceManager : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private PlayerInventory _playerInventory;

    [Header("Interface elements")]
    [SerializeField] private GameObject _shopInterface;
    [SerializeField] private Transform _itemSlotPool;
    [SerializeField] private Transform _itemSelectionPool;
    [SerializeField] private TMP_Text _totalPrice;

    [Header("Other")]
    [SerializeField] private Sprite _sprNull;

    public void OpenShop()
    {
        _shopInterface.SetActive(true);
        RenderInventory();
    }

    public void CloseShop()
    {
        _shopInterface.SetActive(false);
    }

    //------------------------------------------------------------------

    public void RenderInventory()
    {
        for(int i = 0; i < _itemSlotPool.childCount; i++)
        {
            if(_playerInventory.Items[i] != null)
            {
                _itemSlotPool.GetChild(i).GetChild(0).GetComponent<Image>().sprite = _playerInventory.Items[i].Item.ItemSprite; //Item Sprite
                _itemSlotPool.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text = _playerInventory.Items[i].ItemQuantity.ToString(); //Item Quantity Text
            }
            else
            {
                _itemSlotPool.GetChild(i).GetChild(0).GetComponent<Image>().sprite = _sprNull; //Item Sprite
                _itemSlotPool.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text = ""; //Item Quantity Text
            }
        }
    }

    //------------------------------------------------------------------

    public void SelectItem(bool select, int index)
    {
        _itemSelectionPool.GetChild(index).GetComponent<Image>().enabled = select;
    }

    public void ClearAllSelections()
    {
        for(int i = 0; i < _itemSelectionPool.childCount; i++)
        {
            _itemSelectionPool.GetChild(i).GetComponent<Image>().enabled = false;
        }
    }

    //------------------------------------------------------------------

    public void RenderTotalPrice(int amount)
    {
        _totalPrice.text = "Total price: " + amount;
    }
}
