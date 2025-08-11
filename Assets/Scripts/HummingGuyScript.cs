using UnityEngine;

public class HummingGuyScript : ActionableItem
{
    [SerializeField] private string dialogue;
	[SerializeField] private Transform animLineupLocation;
	[SerializeField] private AudioSource humming;

	public override bool AreActionsCorrect()
	{
		return base.AreActionsCorrect();
	}

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
		DialogueManager.instance.GenerateDialogueIntoAction(dialogue, new UndoableAction("Stop Humming", StopHumming, HummingUndo));
	}

	public void StopHumming()
	{
		humming.Stop();
	}

	public void HummingUndo()
	{
		humming.Play();
	}
}
