using UnityEngine;

public class Room1PuzzleScript : MonoBehaviour
{
	[SerializeField] private DoorScript theDoor;
	[SerializeField] private DoorScript doorBars;
	[SerializeField] private Collider2D doorTravelTrigger;

	[SerializeField] private AudioClip buttonClick;

	[SerializeField] private ProgressiveUnlock crack;
	[SerializeField] private GameObject crackInspect;

	private void Start()
	{
		theDoor.CloseInstant();
		doorBars.OpenInstant();
		doorTravelTrigger.enabled = false;

		crackInspect.SetActive(false);
	}

	private void Update()
	{
		doorTravelTrigger.enabled = (theDoor.open && doorBars.open);

		if (doorBars.updateCrack)
		{
			doorBars.updateCrack = false;
			Crack();
		}
		if (theDoor.updateCrack)
		{
			theDoor.updateCrack = false;
			Crack();
		}
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
						UnCrack();
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
						UnCrack();
					}
					if (Button2bars2)
					{
						doorBars.OpenInstant();
					}
					else
					{
						UnCrack();
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
						UnCrack();
					}
					if (Button3bars2)
					{
						doorBars.CloseInstant();
					}
					else
					{
						UnCrack();
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
						UnCrack();
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
						UnCrack();
					}
					if (Button2bars)
					{
						doorBars.OpenInstant();
					}
					else
					{
						UnCrack();
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
						UnCrack();
					}
					if (Button3bars)
					{
						doorBars.CloseInstant();
					}
					else
					{
						UnCrack();
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

	public void Crack()
	{
		if (crack.GetProgress() > 0)
		{
			crackInspect.SetActive(true);
		}
		crack.Progress();
	}

	public void UnCrack()
	{
		if (crack.GetProgress() <= 0)
		{
			crackInspect.SetActive(false);
		}
		crack.Regress();
	}
}
