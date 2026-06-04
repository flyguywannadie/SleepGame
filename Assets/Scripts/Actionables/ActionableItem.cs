using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionableItem : MonoBehaviour
{
	[SerializeField] protected string actionName = "Base Action ";
	[SerializeField] protected CursorAction expectedAction;

	protected virtual void Execute() { }

	protected virtual void Undo(bool removing) { }

	public virtual bool AreActionsCorrect()
	{
		CursorAction current = InteractionManager.instance.GetCurrentAction();

		return expectedAction == current;
	}

	public virtual void DoTheAction()
	{
		//GameManager.instance.AddActionToStack(new UndoableAction(actionName, Execute, Undo));
		Execute();
	}

	private void OnMouseOver()
	{
		if (AreActionsCorrect() && InteractionManager.instance.AreActionsEnabled())
		{
			bool doaction = false;

			if (InteractionManager.instance.IsUsingItem())
			{
				doaction = Input.GetMouseButtonUp(0);
			}
			else
			{
				doaction = Input.GetMouseButtonDown(0);
			}

			if (doaction)
			{
				DoTheAction();
			}
		}
	}

	//private void OnMouseEnter()
	//{
	//	if (AreActionsCorrect())
	//	{
	//		InteractionManager.instance.IsPossibleToInteract();
	//	}
	//}

	//private void OnMouseExit()
	//{
	//	InteractionManager.instance.NotPossibleToInteract();
	//}
}
