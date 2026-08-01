using UnityEngine;

public class ShopDoor : MonoBehaviour, IInteractable
{
    [Header("External scripts")]
    [SerializeField] private ShopManager _shopManager;

    public void Interact()
    {
        _shopManager.OpenShop();
    }
}
