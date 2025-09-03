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

	[SerializeField] private bool tutorialDone = false;
	[SerializeField] private GameObject undoTutorial;

	[SerializeField] private int currentSound = 0;
	[SerializeField] private List<AudioSource> soundPlayers;

	[SerializeField] private AudioClip undoSound;

	private void Awake()
	{
		instance = this;
		if (!MainMenu)
		{
			undoTutorial.SetActive(false);
		} else
		{
			Cursor.visible = true;
		}
	}

	public void AddActionToStack(UndoableAction a)
	{
		actionStack.Add(a);
		a.Execute();

		if (!tutorialDone && actionStack.Count > 5)
		{
			undoTutorial.SetActive(true);
		}
	}

	/// <summary>
	/// This is to add bonus Undos to actions that may be have different outcomes based on the state of other things<br/>
	/// <br/>
	/// example: <br/>
	///		When pressing a button change X -> Y<br/>
	///		If the button is pressed on X, you want it to undo back into X<br/>
	///		If the button is pressed on Y, you don't want it to undo back to X because then the Undo isn't proper<br/>
	///	<br/>
	/// Can also be used for 
	/// </summary>
	public void AddConditionalUndo(Action a)
	{
		actionStack[actionStack.Count - 1].AddUndo(a);
	}

	public void UndoAction()
	{
		DialogueManager.instance.CloseDialogueUndo();

		if (actionStack.Count <= 0)
		{
			return;
		}
		PlaySound(undoSound);

		int index = actionStack.Count - 1;
		actionStack[index].Undo();
		actionStack.RemoveAt(index);

		PlayerScript.instance.ForceIdleAnim();

		if (!tutorialDone)
		{
			undoTutorial.SetActive(false);
			tutorialDone = true;
		}
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

	public void PlaySound(AudioClip audio)
	{
		currentSound++;
		if (currentSound >= soundPlayers.Count)
		{
			currentSound = 0;
		}
		soundPlayers[currentSound].PlayOneShot(audio);
	}

	public bool IsGamePaused()
	{
		return pauseManager.IsGamePaused();
	}

	public void EndGame()
	{
		MainMenu = true;
		pauseManager.GoToSleep();
	}
}
