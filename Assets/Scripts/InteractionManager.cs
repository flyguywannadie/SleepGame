using UnityEngine;
using static UnityEditor.PlayerSettings;

public enum PlayerAction
{
	LOOK = 0,
	TOUCH = 1,
	MOVE = 2,
}

public class InteractionManager : MonoBehaviour
{
	public static InteractionManager instance { get; private set; }

	[SerializeField] private PlayerAction currentAction;

	[SerializeField] private CursorScript cursor;

	[SerializeField] private int hoverCount = 0;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		ChangeActionLook();
	}

	public PlayerAction GetCurrentAction()
	{
		return currentAction;
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
	}
	public void ChangeActionTouch()
	{
		ChangeAction(PlayerAction.TOUCH);
	}
	public void ChangeActionMove()
	{
		ChangeAction(PlayerAction.MOVE);
	}

	public void ChangeAction(PlayerAction s)
	{
		currentAction = s;
		cursor.SetCursor(s);
	}
}
