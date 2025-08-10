using UnityEngine;

public class FloorAction : ActionableItem
{
	public override void DoTheAction()
	{
		GameManager.instance.ForcePlayerMovement(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
}
