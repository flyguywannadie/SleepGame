using UnityEngine;

public class DoorScript : MonoBehaviour
{
	[SerializeField] private Animator doorAnims;
	[SerializeField] private Animator barsAnims;

	public void OpenDoor()
	{
		doorAnims.SetBool("Open", true);
	}

	public void CloseDoor()
	{
		doorAnims.SetBool("Open", false);
	}

	public void OpenDoorInstant()
	{
		doorAnims.SetBool("Open", true);
		doorAnims.Play("Opened");
	}

	public void CloseDoorInstant()
	{
		doorAnims.SetBool("Open", false);
		doorAnims.Play("Closed");
	}

	public void RemoveBars()
	{
		barsAnims.SetBool("Open", true);
	}

	public void SetUpBars()
	{
		barsAnims.SetBool("Open", false);
	}

	public void RemoveBarsInstant()
	{
		barsAnims.SetBool("Open", true);
		barsAnims.Play("Opened");
	}

	public void SetUpBarsInstant()
	{
		barsAnims.SetBool("Open", false);
		barsAnims.Play("Closed");
	}
}
