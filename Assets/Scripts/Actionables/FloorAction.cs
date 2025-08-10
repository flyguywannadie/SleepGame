using UnityEngine;

public class FloorAction : ActionableItem
{
	public override void DoTheAction()
	{
		PlayerScript.instance.MovePlayer(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
}
