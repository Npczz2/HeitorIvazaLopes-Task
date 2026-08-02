using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private DungeonInterfaceManager _dungeonInterfaceManager;
    [SerializeField] private PlayerInventory _playerInventory;

    [Header("Other")]
    [SerializeField] private GameObject _dungeonInstructionObject;

    private ItemListHolder _itemListHolder;

    public bool CombatStarted {get; private set;} = false;

    private float _dungeonTimer;

    private int[] _obtainedItemCount;

    void Awake()
    {
        _itemListHolder = GetComponent<ItemListHolder>();
        _obtainedItemCount = new int[3];
    }

    void Update()
    {
        if(CombatStarted) CountDungeonTimer();
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

    //------------------------------------------------------------------

    void StartCombat()
    {
        _dungeonInstructionObject.SetActive(false);
        CombatStarted = true;
    }

    //------------------------------------------------------------------

    public void GetCombatStartInput(InputAction.CallbackContext context)
{
    if(context.performed)
    {
        StartCombat();
    }
}
}
