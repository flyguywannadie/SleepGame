using UnityEngine;

public class CabinetDoorAction : ActionableItem
{
	[SerializeField] private KitchenCabinetScript cabinet;
	[SerializeField] private bool leftDoor;

	public override void DoTheAction()
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

	//public override void Execute()
	//{

	//}

	//public override void Undo()
	//{
	//	if (leftDoor)
	//	{
	//		cabinet.LeftUndo();
	//	}
	//	else
	//	{
	//		cabinet.RightUndo();
	//	}
	//}
}
