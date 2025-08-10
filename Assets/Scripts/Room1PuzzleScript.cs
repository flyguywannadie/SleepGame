using UnityEngine;

public class Room1PuzzleScript : MonoBehaviour
{
	[SerializeField] private DoorScript connectedDoor;

	private void Start()
	{
		connectedDoor.CloseDoorInstant();
		connectedDoor.RemoveBarsInstant();
	}

	public void Button(int which)
	{
		Debug.Log("Button " + which + " Pressed");


		switch (which)
		{
			case 0:
				connectedDoor.SetUpBars();
				break;
			case 1:
				connectedDoor.OpenDoor();
				break;
			case 2:
				connectedDoor.CloseDoor();
				connectedDoor.RemoveBars();
				break;
		}
	}

	public void ButtonUndo(int which)
	{
		Debug.Log("Button " + which + " Undone");

		switch (which)
		{
			case 0:
				connectedDoor.RemoveBarsInstant();
				break;
			case 1:
				connectedDoor.CloseDoorInstant();
				break;
			case 2:
				connectedDoor.OpenDoorInstant();
				connectedDoor.SetUpBarsInstant();
				break;
		}
	}
}
