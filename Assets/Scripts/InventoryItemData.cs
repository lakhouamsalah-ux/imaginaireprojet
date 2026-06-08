using UnityEngine;

[CreateAssetMenu(menuName = "VR/Inventory Item")]
public class InventoryItemData : ScriptableObject
{
    public string itemId;
    public GameObject prefab;
    public Sprite icon;
}