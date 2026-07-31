using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public int ItemID;
    public string ItemName;
    public string ItemDescription;
    public Sprite ItemSprite;
    public int ItemPrice;
}
