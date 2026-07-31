using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    private Vector3 _cameraDistance = new Vector3(0f, 0.4f, -1.5f);

    void Update()
    {
        transform.position = _targetTransform.position + _cameraDistance;
    }
}
