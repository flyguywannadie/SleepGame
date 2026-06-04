using UnityEngine;

public class UseItemAction : BaseWalkupAction
{
	public override void DoTheAction()
	{
        InventoryScript.instance.UseItem();
        gameObject.SetActive(false);
	}

	//public override void Execute()
	//{

	//}

	//public override void Undo()
	//{
	//	InventoryScript.instance.Undo();
	//	gameObject.SetActive(true);
	//}
}
