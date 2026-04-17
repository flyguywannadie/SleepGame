using UnityEngine;

public class DoorwayAction : ActionableItem
{
	[SerializeField] private Transform animLineupLocation;
	[SerializeField] private DoorwayAction whereIGo;
	[SerializeField] private Transform myTravelLocation;
	[SerializeField] private Transform myTravelEndLocation;
	[SerializeField] private CameraTrack myCameraTrack;
	//[SerializeField] private CameraTrack undoTrack;

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
		GameManager.instance.SetCameraTrack(whereIGo.GetCameraTrack());
		PlayerScript.instance.ForcePosition(whereIGo.GetTravelToLocation().position);
		PlayerScript.instance.MovePlayerNoUndo(whereIGo.GetTravelWalkLocation().position);
	}

	public override void Undo()
	{
		GameManager.instance.SetCameraTrack(myCameraTrack);
		PlayerScript.instance.ForcePosition(animLineupLocation.position);
	}

	public Transform GetTravelToLocation()
	{
		return myTravelLocation;
	}

    public Transform GetTravelWalkLocation()
    {
        return myTravelEndLocation;
    }

	public CameraTrack GetCameraTrack()
	{
		return myCameraTrack;
	}
}
