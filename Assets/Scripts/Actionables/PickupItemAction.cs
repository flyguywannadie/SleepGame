using UnityEngine;

public class PickupItemAction : BaseWalkupAction
{
	[SerializeField] private ItemDataSO pickup;
	[SerializeField] private SpriteRenderer visuals;

    public override bool AreActionsCorrect()
	{
		if (!InventoryScript.instance.CanAddItem())
		{
			return false;
		}
		return base.AreActionsCorrect();
	}

    protected override void Execute()
    {
        InventoryScript.instance.AddItem(pickup);
        gameObject.SetActive(false);
    }

	public void SetPickup(ItemDataSO pickup)
	{
		this.pickup = pickup;
		visuals.sprite = pickup.itemImage;
	}

 //   public override void Execute()
	//{

	//}

	//public override void Undo()
	//{
	//	InventoryScript.instance.Undo();
	//	InteractionManager.instance.UnselectAction(pickup.actionCursor.itemAction);
	//	gameObject.SetActive(true);
	//}
}
