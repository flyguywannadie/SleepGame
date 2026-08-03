using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
	[SerializeField] protected Image visuals;
	//[SerializeField] protected PlayerAction action;
	[SerializeField] protected Sprite UnPressed;
	[SerializeField] protected Sprite Pressed;

	[SerializeField] protected ActionCursorSO defaultCursor;
	[SerializeField] protected CursorAction itemAction;

    [SerializeField] private bool startPressed = false;

	private void Start()
	{
		if (startPressed)
		{
			Press();
		} else
		{
			UnPress();
		}
	}

	public virtual void Press()
	{
		visuals.sprite = Pressed;
		InteractionManager.instance.ChangeAction(this);
	}

	public virtual void UnPress()
	{
		visuals.sprite = UnPressed;
	}

	public CursorAction GetAction()
	{
		return itemAction;
	}

	public ActionCursorSO GetActionCursor()
	{
		return defaultCursor;
	}
}
