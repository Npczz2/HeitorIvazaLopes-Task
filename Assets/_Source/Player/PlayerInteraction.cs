using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private Transform _raycastOrigin;
    private float _interactionRadius = 0.5f;

    private GameObject _collidingObject;

    [Header("Other")]
    [SerializeField] private GameObject _interactionUI;

    void Awake()
    {
        _raycastOrigin = transform;
    }

    void FixedUpdate()
    {
        RaycastDetection();
    }

    //------------------------------------------------------------------

    public void GetInteractionInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(_collidingObject != null)
            {
                _collidingObject.GetComponent<IInteractable>().Interact();
            }
        }
    }

    //------------------------------------------------------------------

    void RaycastDetection()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_raycastOrigin.position, _interactionRadius);

        bool anyCollision = false;

        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.transform.gameObject.CompareTag("Item") || hitCollider.transform.gameObject.CompareTag("NPC") || hitCollider.transform.gameObject.CompareTag("Dungeon Door"))
            {
                _collidingObject = hitCollider.transform.gameObject;
                EnableOrDisableInteractionUI(true);

                anyCollision = true;
            }
        }

        if(!anyCollision) EnableOrDisableInteractionUI(false);
    }

    void EnableOrDisableInteractionUI(bool enable)
    {
        if(_interactionUI.activeInHierarchy == enable) return;

        _interactionUI.SetActive(enable);
    }
}
