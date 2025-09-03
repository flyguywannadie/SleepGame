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
		base.DoTheAction();
	}

	public override void Execute()
	{
		if (shedDoor.open)
		{
			shedDoor.Close();
		}
		else
		{
			shedDoor.Open();
		}
	}

	public override void Undo()
	{
		if (shedDoor.open)
		{
			shedDoor.CloseInstant();
		} else
		{
			shedDoor.OpenInstant();
		}
	}
}
