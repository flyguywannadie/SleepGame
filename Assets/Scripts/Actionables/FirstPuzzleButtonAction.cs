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
		if (Vector2.Distance(PlayerScript.instance.GetPlayerPos(), animLineupLocation.position) > 0.1f)
		{
			PlayerScript.instance.ForcePlayerMovement(animLineupLocation.position);
			return;
		}
		base.DoTheAction();
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

		switch(whichButton)
		{
			case 0:
				mainPuzzle.FirstButton();
				break;
			case 1:
				mainPuzzle.SecondButton();
				break;
			case 2:
				mainPuzzle.ThirdButton();
				break;
		}
	}

	public override void Undo()
	{
		buttonImage.sprite = buttonUnpressed;
		pressed = false;

		switch (whichButton)
		{
			case 0:
				mainPuzzle.FirstButtonUndo();
				break;
			case 1:
				mainPuzzle.SecondButtonUndo();
				break;
			case 2:
				mainPuzzle.ThirdButtonUndo();
				break;
		}
	}
}
