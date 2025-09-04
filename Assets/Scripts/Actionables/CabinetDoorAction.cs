using UnityEngine;

public class CabinetDoorAction : ActionableItem
{
	[SerializeField] private KitchenCabinetScript cabinet;
	[SerializeField] private bool leftDoor;

	public override void DoTheAction()
	{
		base.DoTheAction();
	}

	public override void Execute()
	{
		if (leftDoor)
		{
			cabinet.LeftDoor();
		} 
		else
		{
			cabinet.RightDoor();
		}
	}

	public override void Undo()
	{
		if (leftDoor)
		{
			cabinet.LeftUndo();
		}
		else
		{
			cabinet.RightUndo();
		}
	}
}
