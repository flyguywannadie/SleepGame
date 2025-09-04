using UnityEngine;

public class PickupItemAction : BaseWalkupAction
{
	[SerializeField] private ItemDataSO pickup;

	public override bool AreActionsCorrect()
	{
		if (!InventoryScript.instance.CanAddItem())
		{
			return false;
		}
		return base.AreActionsCorrect();
	}

	public override void Execute()
	{
		InventoryScript.instance.AddItem(pickup);
		gameObject.SetActive(false);
	}

	public override void Undo()
	{
		InventoryScript.instance.Undo();
		gameObject.SetActive(true);
	}
}
