using System.Collections.Generic;

public class PlayerData
{
    public List<QuantifiedItemSaveData> PlayerItems;
    public int PlayerGold;
}

//------------------------------------------------------------------

[System.Serializable]
public class QuantifiedItemSaveData
{
    public int ItemID;
    public int ItemQuantity;
    public int ItemSlot;

    public QuantifiedItemSaveData(int id, int quantity, int slot)
    {
        this.ItemID = id;
        this.ItemQuantity = quantity;
        this.ItemSlot = slot;
    }
}
