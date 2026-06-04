using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAction
{
    [SerializeField] protected string name = "Action";
    [SerializeField] private Action executeActions;
    //[SerializeField] private List<Action> undoActions;

	public PlayerAction() { }
	public PlayerAction(Action execute)
	{
		executeActions = execute;
		//undoActions = new List<Action>(){ undo };
	}
	public PlayerAction(string name, Action execute)
	{
		this.name = name;
		executeActions = execute;
		//undoActions = new List<Action>() { undo };
	}

	public virtual void Execute()
    {
		Debug.Log(name + " was Executed");
		executeActions.Invoke();
	}

    public virtual void Undo() {
		//Debug.Log(name + " was Undone");
		//foreach (Action undo in undoActions)
		//{
		//	undo.Invoke();
		//}
	}

	public virtual void AddUndo(Action undo)
	{
		//undoActions.Add(undo);
	}

	public string GetName()
	{
		return name;
	}
}
