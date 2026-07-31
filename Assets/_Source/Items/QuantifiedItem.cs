using UnityEngine;

public class QuantifiedItem
{
    public ItemScriptableObject Item;
    public int ItemQuantity;

    public QuantifiedItem(ItemScriptableObject item, int quantity)
    {
        this.Item = item;
        this.ItemQuantity = quantity;
    }
}
