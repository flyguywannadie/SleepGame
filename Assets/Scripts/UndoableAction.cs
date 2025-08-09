using System;
using UnityEngine;

public abstract class UndoableAction
{
    [SerializeField] protected string name = "Normal Action";

    public virtual void Execute()
    {
        Debug.Log(name + " was Executed");
        GameManager.instance.AddActionToStack(this);
    }

    public virtual void Undo() {
		Debug.Log(name + " was Undone");
	}
}
