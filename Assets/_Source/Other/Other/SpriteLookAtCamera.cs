using UnityEngine;

public class SpriteLookAtCamera : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(new Vector3(Camera.main.transform.position.x , transform.position.y, Camera.main.transform.position.z));
    }
}
