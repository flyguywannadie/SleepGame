using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
	[SerializeField] protected Image visuals;
	[SerializeField] protected PlayerAction action;
	[SerializeField] protected Sprite UnPressed;
	[SerializeField] protected Sprite Pressed;

	private void Awake()
	{
		UnPress();
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

	public PlayerAction GetAction()
	{
		return action;
	}
}
