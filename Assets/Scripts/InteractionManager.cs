using UnityEngine;
using UnityEngine.UI;

public enum PlayerAction
{
	LOOK = 0,
	TOUCH = 1,
	MOVE = 2,
	HAMMER = 3,
}

public class InteractionManager : MonoBehaviour
{
	public static InteractionManager instance { get; private set; }

	[SerializeField] private PlayerAction currentAction;

	[SerializeField] private PlayerAction prevAction;

	[SerializeField] private CursorScript cursor;

	[SerializeField] private int hoverCount = 0;

	[SerializeField] private bool interactionEnabled;

	[SerializeField] private Image lookButton;
	[SerializeField] private Image touchButton;
	[SerializeField] private Image MoveButton;

	[SerializeField] private Sprite lookUnPressed;
	[SerializeField] private Sprite lookPressed;

	[SerializeField] private Sprite touchUnPressed;
	[SerializeField] private Sprite touchPressed;

	[SerializeField] private Sprite moveUnPressed;
	[SerializeField] private Sprite movePressed;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		ChangeActionLook();
		//Invoke("EnableInteractions", 2.0f);
	}

	public PlayerAction GetCurrentAction()
	{
		return currentAction;
	}

	public bool IsUsingItem()
	{
		return (int)currentAction > (int)PlayerAction.MOVE;
	}

	public void IsPossibleToInteract()
	{
		cursor.SetInteractAnim(true);
		hoverCount++;
	}

	public void NotPossibleToInteract()
	{
		hoverCount = Mathf.Max(0, hoverCount - 1);
		if (hoverCount <= 0)
		{
			cursor.SetInteractAnim(false);
		}
	}

	public bool AreActionsEnabled()
	{
		return interactionEnabled;
	}

	public void EnableInteractions()
	{
		interactionEnabled = true;
		cursor.ShowCursor();
	}

	public void DisableInteractions()
	{
		interactionEnabled = false;
		cursor.HideCursor();
	}

	//public void UsePlayerAction()
	//{
	//	switch (currentAction)
	//	{
	//		case PlayerAction.LOOK:
	//			break;
	//		case PlayerAction.TOUCH:
	//			break;
	//		case PlayerAction.MOVE:
	//			GameManager.instance.ForcePlayerMovement(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	//			break;
	//	}
	//}

	public void ChangeActionLook()
	{
		ChangeAction(PlayerAction.LOOK);
		lookButton.sprite = lookPressed;
		touchButton.sprite = touchUnPressed;
		MoveButton.sprite = moveUnPressed;
	}
	public void ChangeActionTouch()
	{
		ChangeAction(PlayerAction.TOUCH);
		lookButton.sprite = lookUnPressed;
		touchButton.sprite = touchPressed;
		MoveButton.sprite = moveUnPressed;
	}
	public void ChangeActionMove()
	{
		ChangeAction(PlayerAction.MOVE);
		lookButton.sprite = lookUnPressed;
		touchButton.sprite = touchUnPressed;
		MoveButton.sprite = movePressed;
	}

	public void ChangeAction(PlayerAction s)
	{
		prevAction = currentAction;
		currentAction = s;
		cursor.SetCursor(s);
	}

	public void ChangeActionPrev()
	{
		currentAction = prevAction;
		cursor.SetCursor(prevAction);
	}
}
