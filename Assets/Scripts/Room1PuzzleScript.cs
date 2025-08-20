using UnityEngine;

public class Room1PuzzleScript : MonoBehaviour
{
	[SerializeField] private DoorScript theDoor;
	[SerializeField] private DoorScript doorBars;
	[SerializeField] private Collider2D doorTravelTrigger;

	[SerializeField] private AudioClip buttonClick;

	[SerializeField] private GameObject smallCrack;
	[SerializeField] private GameObject midCrack;
	[SerializeField] private GameObject hammerCrack;

	[SerializeField] private int jams = 0;

	private void Start()
	{
		theDoor.CloseInstant();
		doorBars.OpenInstant();
		doorTravelTrigger.enabled = false;

		smallCrack.SetActive(false);
		midCrack.SetActive(false);
		hammerCrack.SetActive(false);
	}

	private void Update()
	{
		doorTravelTrigger.enabled = (theDoor.open && doorBars.open);
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

		GameManager.instance.PlaySound(buttonClick);

		theDoor.UnJam();

		switch (which)
		{
			case 0:
				if (doorBars.open)
				{
					doorBars.Close();
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
					doorBars.Jam();
				}
				break;
			case 1:
				if (!theDoor.open)
				{
					theDoor.Open();
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
					theDoor.Jam();
				}
				if (doorBars.open)
				{
					doorBars.Close();
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
					doorBars.Jam();
				}
				break;
			case 2:
				if (theDoor.open)
				{
					theDoor.Close();
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
					theDoor.Jam();
				}
				if (!doorBars.open)
				{
					doorBars.Open();
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
					doorBars.Jam();
				}
				break;
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
						doorBars.OpenInstant();
					}
					else
					{
						doorBars.RemoveJam();
					}
					Button1bars2 = false;
					break;
				case 1:
					if (Button2door2)
					{
						theDoor.CloseInstant();
					}
					else
					{
						theDoor.RemoveJam();
					}
					if (Button2bars2)
					{
						doorBars.OpenInstant();
					}
					else
					{
						doorBars.RemoveJam();
					}
					Button2door2 = false;
					Button2bars2 = false;
					break;
				case 2:
					if (Button3door2)
					{
						theDoor.OpenInstant();
					}
					else
					{
						theDoor.RemoveJam();
					}
					if (Button3bars2)
					{
						doorBars.CloseInstant();
					}
					else
					{
						doorBars.RemoveJam();
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
						doorBars.OpenInstant();
					}
					else
					{
						doorBars.RemoveJam();
					}
					Button1bars = false;
					break;
				case 1:
					if (Button2door)
					{
						theDoor.CloseInstant();
					}
					else
					{
						theDoor.RemoveJam();
					}
					if (Button2bars)
					{
						doorBars.OpenInstant();
					}
					else
					{
						doorBars.RemoveJam();
					}
					Button2door = false;
					Button2bars = false;
					break;
				case 2:
					if (Button3door)
					{
						theDoor.OpenInstant();
					}
					else
					{
						theDoor.RemoveJam();
					}
					if (Button3bars)
					{
						doorBars.CloseInstant();
					}
					else
					{
						doorBars.RemoveJam();
					}
					Button3door = false;
					Button3bars = false;
					break;
			}
		}
	}

	[SerializeField] private bool Hammer1bars = false;
	[SerializeField] private bool Hammer2door = false;
	[SerializeField] private bool Hammer2bars = false;
	[SerializeField] private bool Hammer3door = false;
	[SerializeField] private bool Hammer3bars = false;

	public void HammerButton(int which)
	{
		switch (which)
		{
			case 0:
				if (!doorBars.open)
				{
					doorBars.Open();
					Hammer1bars = true;
				}
				break;
			case 1:
				if (theDoor.open)
				{
					theDoor.Close();
					Hammer2door = true;
				}
				if (!doorBars.open)
				{
					doorBars.Open();
					Hammer2bars = true;
				}
				break;
			case 2:
				if (!theDoor.open)
				{
					theDoor.Open();
					Hammer3door = true;
				}
				if (doorBars.open)
				{
					doorBars.Close();
					Hammer3bars = true;
				}
				break;
		}
	}

	public void HammerButtonUndo(int which)
	{
		switch (which)
		{
			case 0:
				if (Hammer1bars)
				{
					doorBars.CloseInstant();
				}
				Hammer1bars = false;
				break;
			case 1:
				if (Hammer2door)
				{
					theDoor.OpenInstant();
				}
				if (Hammer2bars)
				{
					doorBars.CloseInstant();
				}
				Hammer2door = false;
				Hammer2bars = false;
				break;
			case 2:
				if (Hammer3door)
				{
					theDoor.CloseInstant();
				}
				if (Hammer3bars)
				{
					doorBars.OpenInstant();
				}
				Hammer3door = false;
				Hammer3bars = false;
				break;
		}
	}

	public void UpdateCrack()
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
}
