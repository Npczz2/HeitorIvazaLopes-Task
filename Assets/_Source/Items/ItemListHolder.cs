using System.Collections.Generic;
using UnityEngine;

public class ItemListHolder : MonoBehaviour
{
    [SerializeField] private List<ItemScriptableObject> _itemList = new List<ItemScriptableObject>();

    public ItemScriptableObject GetItemByID(int index)
    {
        return _itemList[index];
    }

    public ItemScriptableObject GetRandomItem()
    {
        int r = Random.Range(0, _itemList.Count);
        return _itemList[r];
    }
}
