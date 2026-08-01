using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppableObject : MonoBehaviour, IDropHandler
{
    public int SlotIndex;

    [Header("External scripts")]
    [SerializeField] private PlayerInventory _playerInventory;
    private RectTransform _rectTransform;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            StartCoroutine(SwapInventoryCorroutine(eventData.pointerDrag.GetComponent<DraggableObject>().SlotIndex, SlotIndex));
        }
    }

    IEnumerator SwapInventoryCorroutine(int fromIndex, int toIndex)
    {
        yield return null; //Time for the draggable object child return to base parent
        _playerInventory.SwapInventorySlots(fromIndex, toIndex);
    }
}