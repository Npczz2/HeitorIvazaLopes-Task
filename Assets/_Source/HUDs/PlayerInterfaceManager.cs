using UnityEngine;

public class PlayerInterfaceManager : MonoBehaviour
{
    [Header("Interface elements")]
    [SerializeField] private Transform _playerLifePool;

    public void RenderLife(int life)
    {
        for(int i = 0; i < _playerLifePool.childCount; i++)
        {
            _playerLifePool.GetChild(i).gameObject.SetActive(i < life);
        }
    }
}
