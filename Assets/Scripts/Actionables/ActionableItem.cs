using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionableItem : MonoBehaviour, IPointerEnterHandler
{
	[SerializeField] protected string actionName = "Base Action ";
	[SerializeField] protected PlayerAction expectedAction;

	public virtual void Execute()
	{
		Debug.Log("Exected");
	}

	public virtual void Undo()
	{
		Debug.Log("Undone");
	}

	public virtual bool AreActionsCorrect()
	{
		PlayerAction current = InteractionManager.instance.GetCurrentAction();

		return expectedAction == current;
	}

	public virtual void DoTheAction()
	{
		GameManager.instance.AddActionToStack(new UndoableAction(actionName, Execute, Undo));
	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (AreActionsCorrect())
			{
				Debug.Log(name + " gaming2");
				DoTheAction();
			}
		}
	}

	private void OnMouseEnter()
	{
		if (AreActionsCorrect())
		{
			InteractionManager.instance.IsPossibleToInteract();
		}
	}

	private void OnMouseExit()
	{
		if (AreActionsCorrect())
		{
			InteractionManager.instance.NotPossibleToInteract();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log(name + " gaming");
	}
}
