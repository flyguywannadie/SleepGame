using UnityEngine;

public class GoToSleepAction : ActionableItem
{
	[SerializeField] private Transform animLineupLocation;

	public override void DoTheAction()
	{
		if (Vector2.Distance(PlayerScript.instance.GetPlayerPos(), animLineupLocation.position) > 0.01f)
		{
			PlayerScript.instance.ForceMovementIntoAction(animLineupLocation.position, new UndoableAction(Execute, Undo));
			return;
		}
		Execute();
	}

	public override void Execute()
	{
		GameManager.instance.EndGame();
	}
}
