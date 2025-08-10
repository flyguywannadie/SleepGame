using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UndoableAction
{
    [SerializeField] protected string name = "Action";
    [SerializeField] private Action executeActions;
    [SerializeField] private Action undoActions;

	public UndoableAction() { }
	public UndoableAction(Action execute, Action undo)
	{
		executeActions = execute;
		undoActions = undo;
	}
	public UndoableAction(string name, Action execute, Action undo)
	{
		this.name = name;
		executeActions = execute;
		undoActions = undo;
	}

	public virtual void Execute()
    {
		Debug.Log(name + " was Executed");
		executeActions.Invoke();
	}

    public virtual void Undo() {
		Debug.Log(name + " was Undone");
		undoActions.Invoke();
	}
}
