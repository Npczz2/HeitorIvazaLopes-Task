using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int _slotIndex;
    [Header("External scripts")]
    [SerializeField] private ShopInterfaceManager _shopInterfaceManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _shopInterfaceManager.ActivateHover(_slotIndex);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _shopInterfaceManager.DeactivateHover();
    }
}
