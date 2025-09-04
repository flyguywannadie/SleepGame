using UnityEngine;

public class UseItemAction : BaseWalkupAction
{
	public override void DoTheAction()
	{
		base.DoTheAction();
	}

	public override void Execute()
	{
		InventoryScript.instance.UseItem();
		gameObject.SetActive(false);
	}

	public override void Undo()
	{
		InventoryScript.instance.Undo();
		gameObject.SetActive(true);
	}
}
