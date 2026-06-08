using UnityEngine;

public class WaistInventoryZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        InventoryGrabbable item =
            other.GetComponent<InventoryGrabbable>();

        if (item == null)
            return;

        if (!item.isClone)
            return;

        item.StoreInInventory();
    }
}