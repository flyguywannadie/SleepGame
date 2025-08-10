using UnityEngine;

public class InspectAction : ActionableItem
{
	[SerializeField] private string dialogue;

	public override void DoTheAction()
	{
		//base.DoTheAction();
		DialogueManager.instance.GenerateDialogue(dialogue);
	}

	public override void Execute()
	{
		//base.Execute();
	}

	public override void Undo()
	{
		//base.Undo();
	}
}
