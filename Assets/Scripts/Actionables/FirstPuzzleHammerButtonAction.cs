using UnityEngine;

public class FirstPuzzleHammerButton : ActionableItem
{
	[SerializeField] private Room1PuzzleScript mainPuzzle;
	[SerializeField] private Transform animLineupLocation;
	[SerializeField] private int whichButton;
	[SerializeField] private Collider2D buttonTrigger;

	[SerializeField] private SpriteRenderer visuals;

	[SerializeField] private Sprite brokeButton;
	[SerializeField] private Sprite undoButton;

	[SerializeField] private AudioClip buttonBreak;

	public override bool AreActionsCorrect()
	{
		return base.AreActionsCorrect();
	}

	public override void DoTheAction()
	{
		if (Vector2.Distance(PlayerScript.instance.GetPlayerPos(), animLineupLocation.position) > 0.01f)
		{
			PlayerScript.instance.ForceMovementIntoAction(animLineupLocation.position, new UndoableAction("HammerButton", Execute, Undo));
			return;
		}
		PlayerScript.instance.PlayActionAnimation("HammerButton", new UndoableAction(actionName, Execute, Undo));
	}

	public override void Execute()
	{
		undoButton = visuals.sprite;
		visuals.sprite = brokeButton;
		GameManager.instance.PlaySound(buttonBreak);
		mainPuzzle.HammerButton(whichButton);
	}

	public override void Undo()
	{
		visuals.sprite = undoButton;
		mainPuzzle.HammerButtonUndo(whichButton);
	}
}
