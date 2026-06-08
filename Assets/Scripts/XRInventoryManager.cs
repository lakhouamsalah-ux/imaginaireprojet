using System.Collections.Generic;
using UnityEngine;

public class XRInventoryManager : MonoBehaviour
{
    public static XRInventoryManager Instance;

    private readonly List<InventoryItemData> inventory =
        new List<InventoryItemData>();

    public IReadOnlyList<InventoryItemData> Inventory => inventory;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddItem(InventoryItemData item)
    {
        inventory.Add(item);

        Debug.Log($"Added {item.itemId} to inventory");
    }

    public bool RemoveItem(InventoryItemData item)
    {
        return inventory.Remove(item);
    }

    public bool Contains(InventoryItemData item)
    {
        return inventory.Contains(item);
    }
}