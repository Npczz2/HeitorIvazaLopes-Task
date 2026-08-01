using UnityEngine;

public class PlayerScenePersistentData : MonoBehaviour
{
    public QuantifiedItem[] StoredItems {get; private set;}

    void Awake()
    {
        StoredItems = new QuantifiedItem[20];

        DontDestroyOnLoad(this.gameObject);    
    }

    public void StoreItems(QuantifiedItem[] items)
    {
        StoredItems = items;
    }
}
