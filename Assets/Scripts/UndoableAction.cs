using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UndoableAction
{
    [SerializeField] protected string name = "Action";
    [SerializeField] private Action executeActions;
    [SerializeField] private List<Action> undoActions;

	public UndoableAction() { }
	public UndoableAction(Action execute, Action undo)
	{
		executeActions = execute;
		undoActions = new List<Action>(){ undo };
	}
	public UndoableAction(string name, Action execute, Action undo)
	{
		this.name = name;
		executeActions = execute;
		undoActions = new List<Action>() { undo };
	}

	public virtual void Execute()
    {
		Debug.Log(name + " was Executed");
		executeActions.Invoke();
	}

    public virtual void Undo() {
		Debug.Log(name + " was Undone");
		foreach (Action undo in undoActions)
		{
			undo.Invoke();
		}
	}

	public virtual void AddUndo(Action undo)
	{
		undoActions.Add(undo);
	}

	public string GetName()
	{
		return name;
	}
}
