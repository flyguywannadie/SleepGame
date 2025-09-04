using UnityEngine;

public class BaseWalkupAction : ActionableItem
{
	[SerializeField] private string actionAnimName = "Base Walkup";
	[SerializeField] private Transform animLineupLocation;

	public override void DoTheAction()
	{
		if (Vector2.Distance(PlayerScript.instance.GetPlayerPos(), animLineupLocation.position) > 0.01f)
		{
			PlayerScript.instance.ForceMovementIntoAction(animLineupLocation.position, new UndoableAction(actionAnimName, Execute, Undo));
			return;
		}
		PlayerScript.instance.PlayActionAnimation(actionAnimName, new UndoableAction(actionName, Execute, Undo));
	}
}
