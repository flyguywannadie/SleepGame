using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private List<UndoableAction> actionStack;

	[SerializeField] private PlayerScript player;

	private void Awake()
	{
		instance = this;
	}

	public void AddActionToStack(UndoableAction a)
	{
		actionStack.Add(a);
		a.Execute();
	}

	public void UndoAction()
	{
		if (actionStack.Count <= 0)
		{
			return;
		}
		int index = actionStack.Count - 1;
		actionStack[index].Undo();
		actionStack.RemoveAt(index);
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{
			UndoAction();
		}
	}

	public void LoadScene(string scene)
	{
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void ForcePlayerMovement(Vector3 pos)
	{
		player.MoveTo(pos);
	}
}
