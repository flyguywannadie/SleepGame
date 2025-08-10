using UnityEngine;

public class FloorAction : ActionableItem
{
	public override void DoTheAction()
	{
		PlayerScript.instance.ForcePlayerMovement(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
}
