using UnityEngine;

public enum PlayerAction
{
	LOOK = 0,
	TOUCH = 1,
	MOVE = 2,
}

public class InteractionManager : MonoBehaviour
{

	[SerializeField] private PlayerAction currentAction;

	[SerializeField] private CursorScript cursor;

	private void Start()
	{
		ChangeActionLook();
	}

	private void Update()
	{
		
	}

	public void UsePlayerAction()
	{
		switch (currentAction)
		{
			case PlayerAction.LOOK:
				break;
			case PlayerAction.TOUCH:
				break;
			case PlayerAction.MOVE:
				break;
		}
	}

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
