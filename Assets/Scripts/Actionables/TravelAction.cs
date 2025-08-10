using UnityEngine;

public class TravelAction : ActionableItem
{
	[SerializeField] private Transform animLineupLocation;
	[SerializeField] private Transform travelLocation;
	[SerializeField] private Transform travelEndLocation;
	[SerializeField] private CameraTrack travelTrack;
	[SerializeField] private CameraTrack undoTrack;

	public override void DoTheAction()
	{
		if (Vector2.Distance(PlayerScript.instance.GetPlayerPos(), animLineupLocation.position) > 0.01f)
		{
			PlayerScript.instance.ForceMovementIntoAction(animLineupLocation.position, new UndoableAction(Execute, Undo));
			return;
		}
		base.DoTheAction();
	}

	public override void Execute()
	{
		GameManager.instance.SetCameraTrack(travelTrack);
		PlayerScript.instance.ForcePosition(travelLocation.position);
		PlayerScript.instance.MovePlayerNoUndo(travelEndLocation.position);
	}

	public override void Undo()
	{
		GameManager.instance.SetCameraTrack(undoTrack);
		PlayerScript.instance.ForcePosition(animLineupLocation.position);
	}
}
