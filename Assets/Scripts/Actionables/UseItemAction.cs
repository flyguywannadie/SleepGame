using UnityEngine;

public class UseItemAction : BaseWalkupAction
{
    [SerializeField] private int usedItemSlot = 0;

    public override void DoTheAction()
    {
        usedItemSlot = InventoryScript.instance.GetCurrentSlotIndex();
        if (usedItemSlot == -1)
        {
            return;
        }
        base.DoTheAction();
    }

    protected override void Execute()
	{
        InventoryScript.instance.RemoveItemFromSlot(RemoveItemOption.Trash, usedItemSlot);
        gameObject.SetActive(false);
    }

	//public override void Undo()
	//{
	//	InventoryScript.instance.Undo();
	//	gameObject.SetActive(true);
	//}
}
