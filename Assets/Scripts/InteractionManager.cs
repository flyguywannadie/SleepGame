using UnityEngine;

public enum CursorAction
{
	LOOK = 0,
	TOUCH = 1,
	MOVE = 2,
	HAMMER = 3,
	KEY = 4,
}

public class InteractionManager : MonoBehaviour
{
	public static InteractionManager instance { get; private set; }

	[SerializeField] private CursorAction currentAction;

	[SerializeField] private CursorScript cursor;

	[SerializeField] private int hoverCount = 0;

	[SerializeField] private bool interactionEnabled;

	[SerializeField] private ActionButton prevAction;

	[SerializeField] private ActionButton prevNonItemAction;

    [SerializeField] private Animator removeItemButton;

    private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		//ChangeAction(prevAction);
	}

	public CursorAction GetCurrentAction()
	{
		return currentAction;
	}

	public bool IsUsingItem()
	{
		return (int)currentAction > (int)CursorAction.MOVE;
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

	public void ChangeAction(ActionButton ab)
	{
		if (ab != prevAction)
		{
			prevAction.UnPress();
		}
		if (ab.GetAction() <= CursorAction.MOVE && (ab as InventorySpot == null))
		{
            prevNonItemAction = ab;
            removeItemButton.gameObject.SetActive(false);
        }
        else
		{
			removeItemButton.gameObject.SetActive(true);
        }
		currentAction = ab.GetAction();
		cursor.SetCursor(ab.GetActionCursor());
		prevAction = ab;
	}

	public void UnselectAction(CursorAction a)
	{
		if (a == currentAction)
		{
			Debug.Log("Deselecting - " + a.ToString() + " and selecting " + prevNonItemAction.GetAction().ToString());
			prevNonItemAction.Press();
		}
	}
}
