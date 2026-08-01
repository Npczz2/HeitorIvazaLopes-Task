using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private DungeonInterfaceManager _dungeonInterfaceManager;
    [SerializeField] private PlayerInventory _playerInventory;
    private ItemListHolder _itemListHolder;

    private float _dungeonTimer;

    private int[] _obtainedItemCount;

    void Awake()
    {
        _itemListHolder = GetComponent<ItemListHolder>();
        _obtainedItemCount = new int[3];
    }

    void Update()
    {
        CountDungeonTimer();
    }

    void CountDungeonTimer()
    {
        _dungeonTimer += Time.deltaTime;
        _dungeonInterfaceManager.FormatDungeonTime(Mathf.RoundToInt(_dungeonTimer));
    }

    //------------------------------------------------------------------

    public void GetHordeDeathReward()
    {
        ItemScriptableObject item = _itemListHolder.GetRandomItem();
        _playerInventory.AddItem(item);

        _obtainedItemCount[item.ItemID]++;
        _dungeonInterfaceManager.AddItemCounter(item.ItemID, _obtainedItemCount[item.ItemID]);
    }

    //------------------------------------------------------------------

    void ReturnToCity()
    {
        PlayerScenePersistentData.Instance.IsDayTime = false;
        SceneManager.LoadScene("City");
    }

    public void GetLeaveDungeonInput(InputAction.CallbackContext context)
    {
        if(context.performed) ReturnToCity();
    }
}
