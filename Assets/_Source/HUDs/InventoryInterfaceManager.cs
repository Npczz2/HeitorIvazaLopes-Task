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
    [SerializeField] private GameObject _selectionSquare;
    [SerializeField] private Button _useItemButton;
    [SerializeField] private Button _dropItemButton;

    [Header("Selected item interface")]
    [SerializeField] private Image _selectedItemSprite;
    [SerializeField] private TMP_Text _selectedItemName;
    [SerializeField] private TMP_Text _selectedItemDescription;

    [Header("Hover interface")]
    [SerializeField] private GameObject _itemHover;
    [SerializeField] private TMP_Text _hoverItemName;
    [SerializeField] private TMP_Text _hoverItemDescription;

    [Header("Other")]
    [SerializeField] private Sprite _sprNull;
    [SerializeField] private Transform _draggedItemParent;

    public void OpenInventory()
    {
        _inventoryInterface.SetActive(true);

        UnselectItems();
        RenderInventory();
    }

    public void CloseInventory()
    {
        _inventoryInterface.SetActive(false);
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

    public void SelectItem(int index)
    {
        _playerInventory.SelectedItemIndex = index;

        if(!_selectionSquare.activeInHierarchy) _selectionSquare.SetActive(true);
        _selectionSquare.transform.position = _itemSlotPool.GetChild(index).position;

        if(_playerInventory.Items[index] != null)
        {
            _selectedItemSprite.sprite = _playerInventory.Items[index].Item.ItemSprite;
            _selectedItemName.text = _playerInventory.Items[index].Item.ItemName;
            _selectedItemDescription.text = _playerInventory.Items[index].Item.ItemDescription;

            _useItemButton.interactable = true;
            _dropItemButton.interactable = true;
        }
        else
        {
            ClearSelectedItemInfo();
        }
    }
    
    public void UnselectItems()
    {
        ClearSelectedItemInfo();
        _selectionSquare.SetActive(false);
    }

    void ClearSelectedItemInfo()
    {
        _selectedItemSprite.sprite = _sprNull;
        _selectedItemName.text = "";
        _selectedItemDescription.text = "";

        _useItemButton.interactable = false;
        _dropItemButton.interactable = false;
    }

    //------------------------------------------------------------------

    public void DragItem(Transform draggedItem) //Used to increase the rendering order of the dragged item
    {
        draggedItem.SetParent(_draggedItemParent);
    }

    //------------------------------------------------------------------

    public void ActivateHover(int slotIndex)
    {
        if(_playerInventory.Items[slotIndex] == null || _playerInventory.SelectedItemIndex == slotIndex) return;

        _itemHover.SetActive(true);
        _itemHover.transform.localPosition = (_itemSlotPool.GetChild(slotIndex).localPosition + new Vector3(0f, 150f, 0f));

        _hoverItemName.text = _playerInventory.Items[slotIndex].Item.ItemName;
        _hoverItemDescription.text = _playerInventory.Items[slotIndex].Item.ItemDescription;
    }

    public void DeactivateHover()
    {
        _itemHover.SetActive(false);
    }
}
