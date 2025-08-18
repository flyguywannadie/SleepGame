using System;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	public static DialogueManager instance { get; private set; }

	[SerializeField] private TextMeshProUGUI dialogue;
	[SerializeField] private Animator anims;

	private UndoableAction dialogueAction;
	private Action endAction;

	private bool dialogueOpen = false;

	private void Awake()
	{
		instance = this;
	}

	public void GenerateDialogue(string text)
	{
		dialogue.text = text;
		InteractionManager.instance.DisableInteractions();
		anims.SetBool("Open", true);
	}

	public void GenerateDialogueWithEndAction(string text, Action end)
	{
		dialogue.text = text;
		endAction = end;
		InteractionManager.instance.DisableInteractions();
		anims.SetBool("Open", true);
	}

	//public void GenerateDialogueIntoAction(string text, UndoableAction action)
	//{
	//	dialogueAction = action;
	//	dialogue.text = text;
	//	InteractionManager.instance.DisableInteractions();
	//	anims.SetBool("Open", true);
	//}

	public void AnimDialogueOpen()
	{
		dialogueOpen = true;
	}

	private void Update()
	{
		if (dialogueOpen)
		{
			if (Input.anyKeyDown)
			{
				CloseDialogue();
			}
		}
	}

	public void CloseDialogue()
	{
		InteractionManager.instance.EnableInteractions();
		anims.SetBool("Open", false);
		dialogueOpen = false;
		if (dialogueAction != null)
		{
			GameManager.instance.AddActionToStack(dialogueAction);
			dialogueAction = null;
		}
		if (endAction != null)
		{
			endAction.Invoke();
			endAction = null;
		}
	}

	public void CloseDialogueUndo()
	{
		InteractionManager.instance.EnableInteractions();
		anims.SetBool("Open", false);
		anims.Play("Closed");
		dialogueOpen = false;
	}
}
