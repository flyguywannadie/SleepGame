using UnityEngine;

public class BaseDoorScript : MonoBehaviour
{
	[SerializeField] protected Animator doorAnims;

	public bool open = false;

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
}
