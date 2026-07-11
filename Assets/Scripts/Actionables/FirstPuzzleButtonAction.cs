using UnityEngine;

public class FirstPuzzleButtonAction : ActionableItem
{
	[SerializeField] private Room1PuzzleScript mainPuzzle;
	[SerializeField] private Transform animLineupLocation;
	[SerializeField] private int whichButton;
	[SerializeField] private Sprite buttonPressed;
	[SerializeField] private Sprite buttonUnpressed;
	[SerializeField] private SpriteRenderer buttonImage;
	[SerializeField] private int pressed = 0;

	public override void DoTheAction()
	{
		if (Vector2.Distance(PlayerScript.instance.GetPlayerPos(), animLineupLocation.position) > 0.01f)
		{
			PlayerScript.instance.ForceMovementIntoAction(animLineupLocation.position, new PlayerAction("ButtonPress", Execute));
			return;
		}
		PlayerScript.instance.PlayActionAnimation("ButtonPress", new PlayerAction(actionName, Execute));
	}

	public override bool AreActionsCorrect()
	{
		if (pressed > 1)
		{
			return false;
		}
		return base.AreActionsCorrect();
	}

	protected override void Execute()
	{
        pressed += 1;
        if (pressed > 1)
        {
            buttonImage.sprite = buttonPressed;
        }

        mainPuzzle.Button(whichButton);
    }

	//public override void Undo()
	//{
	//	pressed -= 1;
	//	if (pressed < 2)
	//	{
	//		buttonImage.sprite = buttonUnpressed;
	//	}
	//}
}
