using UnityEngine;

public class DoorScript : MonoBehaviour
{
	[SerializeField] private Animator doorAnims;
	[SerializeField] private Animator barsAnims;

	public bool doorOpen = false;
	public bool barsDown = false;

	public void OpenDoor()
	{
		doorAnims.SetBool("Open", true);
		doorOpen = true;
	}

	public void CloseDoor()
	{
		doorAnims.SetBool("Open", false);
		doorOpen = false;
	}

	public void OpenDoorInstant()
	{
		doorAnims.SetBool("Open", true);
		doorAnims.Play("Opened");
		doorOpen = true;
	}

	public void CloseDoorInstant()
	{
		doorAnims.SetBool("Open", false);
		doorAnims.Play("Closed");
		doorOpen = false;
	}

	public void RemoveBars()
	{
		barsAnims.SetBool("Open", true);
		barsDown = true;
	}

	public void SetUpBars()
	{
		barsAnims.SetBool("Open", false);
		barsDown = false;
	}

	public void RemoveBarsInstant()
	{
		barsAnims.SetBool("Open", true);
		barsAnims.Play("Opened");
		barsDown = true;
	}

	public void SetUpBarsInstant()
	{
		barsAnims.SetBool("Open", false);
		barsAnims.Play("Closed");
		barsDown = false;
	}
}
