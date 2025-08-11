using UnityEngine;

public class Room1PuzzleScript : MonoBehaviour
{
	[SerializeField] private DoorScript connectedDoor;
	[SerializeField] private Collider2D doorTravelTrigger;

	[SerializeField] private int jams = 0;
	[SerializeField] private AudioClip buttonClick;
	[SerializeField] private AudioClip jamSound;

	[SerializeField] private GameObject smallCrack;
	[SerializeField] private GameObject midCrack;
	[SerializeField] private GameObject hammerCrack;

	private void Start()
	{
		connectedDoor.CloseDoorInstant();
		connectedDoor.RemoveBarsInstant();
		doorTravelTrigger.enabled = false;

		smallCrack.SetActive(false);
		midCrack.SetActive(false);
		hammerCrack.SetActive(false);
	}

	private void Update()
	{
		doorTravelTrigger.enabled = (connectedDoor.doorOpen && connectedDoor.barsDown);
	}

	// booleans for if the buttons functioned properly. so that they won't undo wrong
	[SerializeField] private bool Button1bars = false;
	[SerializeField] private bool Button1bars2 = false;
	[SerializeField] private bool Button2door = false;
	[SerializeField] private bool Button2door2 = false;
	[SerializeField] private bool Button2bars = false;
	[SerializeField] private bool Button2bars2 = false;
	[SerializeField] private bool Button3door = false;
	[SerializeField] private bool Button3door2 = false;
	[SerializeField] private bool Button3bars = false;
	[SerializeField] private bool Button3bars2 = false;

	public void Button(int which, int pressed)
	{
		Debug.Log("Button " + which + " Pressed");

		int jamCompare = jams;

		GameManager.instance.PlaySound(buttonClick);

		switch (which)
		{
			case 0:
				if (connectedDoor.barsDown)
				{
					connectedDoor.SetUpBars();
					if (pressed > 1)
					{
						Button1bars2 = true;
					} else
					{
						Button1bars = true;
					}
				}
				else
				{
					jams++;
				}
				break;
			case 1:
				if (!connectedDoor.doorOpen)
				{
					connectedDoor.OpenDoor();
					if (pressed > 1)
					{
						Button2door2 = true;
					}
					else
					{
						Button2door = true;
					}
				}
				else
				{
					jams++;
				}
				if (connectedDoor.barsDown)
				{
					connectedDoor.SetUpBars();
					if (pressed > 1)
					{
						Button2bars2 = true;
					}
					else
					{
						Button2bars = true;
					}
				}
				else
				{
					jams++;
				}
				break;
			case 2:
				if (connectedDoor.doorOpen)
				{
					connectedDoor.CloseDoor();
					if (pressed > 1)
					{
						Button3door2 = true;
					}
					else
					{
						Button3door = true;
					}
				}
				else
				{
					jams++;
				}
				if (!connectedDoor.barsDown)
				{
					connectedDoor.RemoveBars();
					if (pressed > 1)
					{
						Button3bars2 = true;
					}
					else
					{
						Button3bars = true;
					}
				}
				else
				{
					jams++;
				}
				break;
		}

		if (jamCompare < jams)
		{
			GameManager.instance.PlaySound(jamSound);
			UpdateCrack();
		}
	}

	private void UpdateCrack()
	{
		if (jams >= 2 && jams < 4)
		{
			smallCrack.SetActive(true);
			midCrack.SetActive(false);
			hammerCrack.SetActive(false);
		}
		else if (jams >= 4 && jams < 6)
		{
			smallCrack.SetActive(false);
			midCrack.SetActive(true);
			hammerCrack.SetActive(false);
		}
		else if (jams >= 6)
		{
			smallCrack.SetActive(false);
			midCrack.SetActive(false);
			hammerCrack.SetActive(true);
		}
		else
		{
			smallCrack.SetActive(false);
			midCrack.SetActive(false);
			hammerCrack.SetActive(false);
		}
	}

	public void ButtonUndo(int which, int pressed)
	{
		Debug.Log("Button " + which + " Undone");

		if (pressed > 0)
		{
			switch (which)
			{
				case 0:
					if (Button1bars2)
					{
						connectedDoor.RemoveBarsInstant();
					}
					else
					{
						jams--;
					}
					Button1bars2 = false;
					break;
				case 1:
					if (Button2door2)
					{
						connectedDoor.CloseDoorInstant();
					}
					else
					{
						jams--;
					}
					if (Button2bars2)
					{
						connectedDoor.RemoveBarsInstant();
					}
					else
					{
						jams--;
					}
					Button2door2 = false;
					Button2bars2 = false;
					break;
				case 2:
					if (Button3door2)
					{
						connectedDoor.OpenDoorInstant();
					}
					else
					{
						jams--;
					}
					if (Button3bars2)
					{
						connectedDoor.SetUpBarsInstant();
					}
					else
					{
						jams--;
					}
					Button3door2 = false;
					Button3bars2 = false;
					break;
			}
		}
		else
		{
			switch (which)
			{
				case 0:
					if (Button1bars)
					{
						connectedDoor.RemoveBarsInstant();
					}
					else
					{
						jams--;
					}
					Button1bars = false;
					break;
				case 1:
					if (Button2door)
					{
						connectedDoor.CloseDoorInstant();
					}
					else
					{
						jams--;
					}
					if (Button2bars)
					{
						connectedDoor.RemoveBarsInstant();
					}
					else
					{
						jams--;
					}
					Button2door = false;
					Button2bars = false;
					break;
				case 2:
					if (Button3door)
					{
						connectedDoor.OpenDoorInstant();
					}
					else
					{
						jams--;
					}
					if (Button3bars)
					{
						connectedDoor.SetUpBarsInstant();
					}
					else
					{
						jams--;
					}
					Button3door = false;
					Button3bars = false;
					break;
			}
		}

		UpdateCrack();
	}

	public void HammerButtonUndo(int which)
	{
		switch (which)
		{
			case 0:
				connectedDoor.RemoveBarsInstant();
				break;
			case 1:
				connectedDoor.CloseDoorInstant();
				connectedDoor.RemoveBarsInstant();
				break;
			case 2:
				connectedDoor.OpenDoorInstant();
				connectedDoor.SetUpBarsInstant();
				break;
		}

		UpdateCrack();
	}
}
