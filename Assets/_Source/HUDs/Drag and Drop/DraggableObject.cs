using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("External Scripts")]
    [SerializeField] private Canvas _canvas;
    [SerializeField] private InventoryInterfaceManager _interfaceManager;

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    private Vector3 _basePos;
    private Transform _baseParent;

    public int SlotIndex {get; private set;}

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();

        _baseParent = transform.parent;

        SlotIndex = transform.parent.GetComponent<DroppableObject>().SlotIndex;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;

        _basePos = transform.localPosition;
        _interfaceManager.DragItem(this.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        transform.parent = _baseParent;
        transform.SetAsFirstSibling();

        transform.localPosition = _basePos;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _interfaceManager.ActivateHover(SlotIndex);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _interfaceManager.DeactivateHover();
    }
}