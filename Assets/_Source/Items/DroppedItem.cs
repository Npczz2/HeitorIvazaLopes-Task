using UnityEngine;

public class DroppedItem : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemScriptableObject _referenceItem;

    public void Interact()
    {
        Debug.Log("Interagiu com o item!");
        Destroy(gameObject); //Replace with collect item logic
    }
}
