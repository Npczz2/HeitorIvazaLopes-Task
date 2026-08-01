using UnityEngine;

public class PlayerScenePersistentData : MonoBehaviour
{
    public static PlayerScenePersistentData Instance;
    public QuantifiedItem[] StoredItems {get; private set;}
    public int Gold {get; private set;} = 0;

    public bool IsDayTime = true;
    public int Day = 1;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        PlayerScenePersistentData.Instance = this;
        DontDestroyOnLoad(this.gameObject);

        StoredItems = new QuantifiedItem[20];
    }

    //------------------------------------------------------------------

    public void StoreItems(QuantifiedItem[] items)
    {
        StoredItems = items;
    }

    public void ClearStoredItems()
    {
        for(int i = 0; i < StoredItems.Length; i++)
        {
            if(StoredItems[i] != null)
            {
                StoredItems[i] = null;
            }
        }
    }

    //------------------------------------------------------------------

    public void AddGold(int amount)
    {
        Gold += amount;
    }

    public void SetGold(int gold)
    {
        Gold = gold;
    }
}
