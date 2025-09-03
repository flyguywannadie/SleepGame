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

	public void Button(int which)
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
					GameManager.instance.AddConditionalUndo(doorBars.OpenInstant);
				}
				else
				{
					doorBars.Jam();
					GameManager.instance.AddConditionalUndo(UnCrack);
				}
				break;
			case 1:
				if (!theDoor.open)
				{
					theDoor.Open();
					GameManager.instance.AddConditionalUndo(theDoor.CloseInstant);
				}
				else
				{
					theDoor.Jam();
					GameManager.instance.AddConditionalUndo(UnCrack);
				}
				if (doorBars.open)
				{
					doorBars.Close();
					GameManager.instance.AddConditionalUndo(doorBars.OpenInstant);
				}
				else
				{
					doorBars.Jam();
					GameManager.instance.AddConditionalUndo(UnCrack);
				}
				break;
			case 2:
				if (theDoor.open)
				{
					theDoor.Close();
					GameManager.instance.AddConditionalUndo(theDoor.OpenInstant);
				}
				else
				{
					theDoor.Jam();
					GameManager.instance.AddConditionalUndo(UnCrack);
				}
				if (!doorBars.open)
				{
					doorBars.Open();
					GameManager.instance.AddConditionalUndo(doorBars.CloseInstant);
				}
				else
				{
					doorBars.Jam();
					GameManager.instance.AddConditionalUndo(UnCrack);
				}
				break;
		}
	}

	public void HammerButton(int which)
	{
		switch (which)
		{
			case 0:
				if (!doorBars.open)
				{
					doorBars.Open();
					GameManager.instance.AddConditionalUndo(doorBars.CloseInstant);
				}
				break;
			case 1:
				if (theDoor.open)
				{
					theDoor.Close();
					GameManager.instance.AddConditionalUndo(theDoor.OpenInstant);
				}
				if (!doorBars.open)
				{
					doorBars.Open();
					GameManager.instance.AddConditionalUndo(doorBars.CloseInstant);
				}
				break;
			case 2:
				if (!theDoor.open)
				{
					theDoor.Open();
					GameManager.instance.AddConditionalUndo(theDoor.CloseInstant);
				}
				if (doorBars.open)
				{
					doorBars.Close();
					GameManager.instance.AddConditionalUndo(doorBars.OpenInstant);
				}
				break;
		}
	}

	public void Crack()
	{
		crack.Progress();
		if (crack.GetProgress() > 1)
		{
			crackInspect.SetActive(true);
		}
	}

	public void UnCrack()
	{
		crack.Regress();
		if (crack.GetProgress() <= 1)
		{
			crackInspect.SetActive(false);
		}
	}
}
