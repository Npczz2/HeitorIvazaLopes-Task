using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class PlayerDataManager : MonoBehaviour
{
    [Header("External scripts")]
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private ItemListHolder _itemListHolder;

    public static PlayerDataManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        PlayerDataManager.Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        LoadGame();
    }

    //------------------------------------------------------------------

    public void SaveGame()
    {
        List<QuantifiedItemSaveData> convertedPlayerItems = ConvertItemsToSaveData();

        PlayerData playerData = new PlayerData();
        playerData.PlayerItems = convertedPlayerItems;

        string json = JsonUtility.ToJson(playerData);
        string path = Application.persistentDataPath + "/playerData.json";
        System.IO.File.WriteAllText(path, json);

        Debug.Log("Items saved.");
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

            if(loadedData.PlayerItems != null) _playerInventory.LoadSavedItems(ConvertLoadedData(loadedData.PlayerItems));
        }
    }

    public void ClearSavedData()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        File.Delete(path);

        Debug.Log("Data cleared.");
    }

    //------------------------------------------------------------------

    List<QuantifiedItemSaveData> ConvertItemsToSaveData()
    {
        List<QuantifiedItemSaveData> convertedPlayerItems = new List<QuantifiedItemSaveData>();

        for(int i = 0; i < _playerInventory.Items.Length; i++)
        {
            if(_playerInventory.Items[i] != null)
            {
                convertedPlayerItems.Add(new QuantifiedItemSaveData(_playerInventory.Items[i].Item.ItemID, _playerInventory.Items[i].ItemQuantity, i));
            }
        }

        return convertedPlayerItems;
    }

    QuantifiedItem[] ConvertLoadedData(List<QuantifiedItemSaveData> loadedItems)
    {
        QuantifiedItem[] convertedItems = new QuantifiedItem[20];

        if(loadedItems.Count > 0)
        {
            for(int i = 0; i < loadedItems.Count; i++)
            {
                ItemScriptableObject item = _itemListHolder.GetItemByID(loadedItems[i].ItemID);

                if(item != null)
                {
                    convertedItems[loadedItems[i].ItemSlot] = new QuantifiedItem(item, loadedItems[i].ItemQuantity);
                }
            }
        }

        return convertedItems;
    }
}