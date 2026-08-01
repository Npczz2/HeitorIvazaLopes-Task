using TMPro;
using UnityEngine;

public class PlayerInterfaceManager : MonoBehaviour
{
    [Header("Interface elements")]
    [SerializeField] private Transform _playerLifePool;
    [SerializeField] private TMP_Text _playerGold;

    void Start()
    {
        RenderGold();
    }

    public void RenderLife(int life)
    {
        for(int i = 0; i < _playerLifePool.childCount; i++)
        {
            _playerLifePool.GetChild(i).gameObject.SetActive(i < life);
        }
    }

    public void RenderGold()
    {
        _playerGold.text = "Gold: " + PlayerScenePersistentData.Instance.Gold.ToString();
    }
}
