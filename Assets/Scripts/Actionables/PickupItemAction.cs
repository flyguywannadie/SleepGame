using UnityEngine;

public class PickupItemAction : ActionableItem
{
	[SerializeField] private ItemDataSO pickup;
	[SerializeField] private Transform animLineupLocation;

	public override void DoTheAction()
	{
		if (Vector2.Distance(PlayerScript.instance.GetPlayerPos(), animLineupLocation.position) > 0.01f)
		{
			PlayerScript.instance.ForceMovementIntoAction(animLineupLocation.position, new UndoableAction("PickupItem", Execute, Undo));
			return;
		}
		PlayerScript.instance.PlayActionAnimation("PickupItem", new UndoableAction(actionName, Execute, Undo));
	}

	public override void Execute()
	{
		InventoryScript.instance.AddItem(pickup);
		gameObject.SetActive(false);
	}

	public override void Undo()
	{
		InventoryScript.instance.RemoveItem();
		gameObject.SetActive(true);
	}
}
