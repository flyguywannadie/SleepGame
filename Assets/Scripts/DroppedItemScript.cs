using UnityEngine;

public class DroppedItemScript : MonoBehaviour
{
    [SerializeField] private PickupItemAction pickedupItem;

    public void SetupItem(ItemDataSO item)
    {
        pickedupItem.SetPickup(item);
    }
}
