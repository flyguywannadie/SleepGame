using UnityEngine;

public class DoorScript : MonoBehaviour
{
	[SerializeField] private Animator doorAnims;

	public bool open = false;

	public bool updateCrack = false;

	public void Open()
	{
		doorAnims.SetBool("Open", true);
		open = true;
	}

	public void Close()
	{
		doorAnims.SetBool("Open", false);
		open = false;
	}

	public void OpenInstant()
	{
		doorAnims.SetBool("Open", true);
		doorAnims.Play("Opened");
		open = true;
	}

	public void CloseInstant()
	{
		doorAnims.SetBool("Open", false);
		doorAnims.Play("Closed");
		open = false;
	}

	public void Jam()
	{
		doorAnims.SetTrigger("Jam");
	}

	public void JamAnim()
	{
		updateCrack = true;
	}

	public void UnJam()
	{
		doorAnims.ResetTrigger("Jam");
	}
}
