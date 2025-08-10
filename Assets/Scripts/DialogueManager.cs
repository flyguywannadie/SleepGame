using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	public static DialogueManager instance { get; private set; }

	[SerializeField] private TextMeshProUGUI dialogue;
	[SerializeField] private Animator anims;

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
	}

	public void CloseDialogueUndo()
	{
		InteractionManager.instance.EnableInteractions();
		anims.SetBool("Open", false);
		anims.Play("Closed");
		dialogueOpen = false;
	}
}
