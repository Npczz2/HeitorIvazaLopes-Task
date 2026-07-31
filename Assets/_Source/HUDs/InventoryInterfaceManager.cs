using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInterfaceManager : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private PlayerInventory _playerInventory;

    [Header("Interface elements")]
    [SerializeField] private GameObject _inventoryInterface;
    [SerializeField] private Transform _itemSlotPool;

    [Header("Other")]
    [SerializeField] private Sprite _sprNull;

    public void OpenInventory()
    {
        _inventoryInterface.SetActive(true);
        RenderInventory();
    }

    public void CloseInventory()
    {
        _inventoryInterface.SetActive(false);
    }

    //------------------------------------------------------------------

    void RenderInventory()
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
}
