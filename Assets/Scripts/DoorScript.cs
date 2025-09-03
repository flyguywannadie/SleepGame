using UnityEngine;

public class DoorScript : BaseDoorScript
{
	public bool updateCrack = false;

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
