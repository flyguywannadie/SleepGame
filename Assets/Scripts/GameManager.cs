using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

	[SerializeField] private bool MainMenu;

    [SerializeField] private List<UndoableAction> actionStack;
	[SerializeField] private PlayerScript player;
	[SerializeField] private PauseManager pauseManager;
	[SerializeField] private CameraScript camManager;

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
		DialogueManager.instance.CloseDialogueUndo();

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
		if (MainMenu)
		{
			return;
		}

		if (!pauseManager.IsGamePaused())
		{
			if (Input.GetKeyDown(KeyCode.Z))
			{
				UndoAction();
			}
			if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
			{
				PauseGame();
			}
		} else
		{
			if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
			{
				UnpauseGame();
			}
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

	public void PauseGame()
	{
		pauseManager.PauseGame();
	}

	public void UnpauseGame()
	{
		pauseManager.UnpauseGame();
	}

	public void SetCameraTrack(CameraTrack track)
	{
		camManager.SetCameraTrack(track);
	}
}
