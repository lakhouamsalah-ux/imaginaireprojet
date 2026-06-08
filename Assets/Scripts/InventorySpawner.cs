using UnityEngine;

public class InventorySpawner : MonoBehaviour
{
    public Transform spawnPoint;

    public void SpawnItem(InventoryItemData item)
    {
        if (!XRInventoryManager.Instance.Contains(item))
            return;

        Instantiate(
            item.prefab,
            spawnPoint.position,
            spawnPoint.rotation);
    }
}