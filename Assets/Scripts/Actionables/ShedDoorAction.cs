using UnityEngine;

public class ShedDoorAction : ActionableItem
{
	[SerializeField] private BaseDoorScript shedDoor;

	public override bool AreActionsCorrect()
	{
		return base.AreActionsCorrect();
	}

	public override void DoTheAction()
	{
		//base.DoTheAction();
        if (shedDoor.open)
        {
            shedDoor.Close();
        }
        else
        {
            shedDoor.Open();
        }
    }

	//public override void Execute()
	//{

	//}

	//public override void Undo()
	//{
	//	if (shedDoor.open)
	//	{
	//		shedDoor.CloseInstant();
	//	} else
	//	{
	//		shedDoor.OpenInstant();
	//	}
	//}
}
