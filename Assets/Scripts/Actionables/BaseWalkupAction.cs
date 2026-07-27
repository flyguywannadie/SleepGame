using UnityEngine;

public class BaseWalkupAction : ActionableItem
{
	[SerializeField] private string actionAnimName = "Base Walkup";
	[SerializeField] protected Transform animLineupLocation;

	public override void DoTheAction()
	{
		if (Vector2.Distance(PlayerScript.instance.GetPlayerPos(), animLineupLocation.position) > 0.01f)
		{
			PlayerScript.instance.ForceMovementIntoAction(animLineupLocation.position, new PlayerAction(actionAnimName, Execute));
			return;
		}
		PlayerScript.instance.PlayAnimationWithAction(new PlayerAction(actionAnimName, Execute));
	}
}
