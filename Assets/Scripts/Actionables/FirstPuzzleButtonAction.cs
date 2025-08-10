using UnityEngine;

public class FirstPuzzleButtonAction : ActionableItem
{
	[SerializeField] private Room1PuzzleScript mainPuzzle;
	[SerializeField] private Transform animLineupLocation;
	[SerializeField] private int whichButton;
	[SerializeField] private Sprite buttonPressed;
	[SerializeField] private Sprite buttonUnpressed;
	[SerializeField] private SpriteRenderer buttonImage;
	[SerializeField] private bool pressed;

	public override void DoTheAction()
	{
		if (Vector2.Distance(PlayerScript.instance.GetPlayerPos(), animLineupLocation.position) > 0.01f)
		{
			PlayerScript.instance.ForceMovementIntoAction(animLineupLocation.position, new UndoableAction("ButtonPress", Execute, Undo));
			return;
		}
		PlayerScript.instance.PlayActionAnimation("ButtonPress", new UndoableAction(actionName, Execute, Undo));
	}

	public override bool AreActionsCorrect()
	{
		if (pressed)
		{
			return false;
		}
		return base.AreActionsCorrect();
	}

	public override void Execute()
	{
		buttonImage.sprite = buttonPressed;
		pressed = true;

		mainPuzzle.Button(whichButton);
	}

	public override void Undo()
	{
		buttonImage.sprite = buttonUnpressed;
		pressed = false;

		mainPuzzle.ButtonUndo(whichButton);
	}
}
