using UnityEngine;

public class FloorAction : ActionableItem
{
	protected override void Execute()
	{
		if (!PlayerScript.instance.GetStairMovement())
		{
			PlayerScript.instance.MovePlayer(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
		else
		{
			PlayerScript.instance.TryExit(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
	}
}
