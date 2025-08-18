using UnityEngine;

public class HummingGuyScript : ActionableItem
{
    [SerializeField] private string dialogue;
	[SerializeField] private Transform animLineupLocation;
	[SerializeField] private AudioSource humming;
	[SerializeField] private Animator anims;

	[SerializeField] private GameObject PawnBedNoSleep;
	[SerializeField] private GameObject PawnBedYesSleep;

	private void Update()
	{
		humming.volume = Mathf.Clamp(0.15f * ((50.0f - Vector3.Distance(PlayerScript.instance.GetPlayerPos(), transform.position)) / 50), 0.05f, 0.15f);
	}

	public override void DoTheAction()
	{
		if (Vector2.Distance(PlayerScript.instance.GetPlayerPos(), animLineupLocation.position) > 0.01f)
		{
			PlayerScript.instance.ForceMovementIntoAction(animLineupLocation.position, new UndoableAction(Execute, Undo));
			return;
		}
		base.DoTheAction();
	}

	public override void Execute()
	{
		if (humming.isPlaying)
		{
			DialogueManager.instance.GenerateDialogueWithEndAction(dialogue, StopTalking);
			humming.Stop();
		}
		else
		{
			DialogueManager.instance.GenerateDialogueWithEndAction("You can go back to bed now.\nI'll be quiet.", StopTalking);
		}
		PawnBedNoSleep.SetActive(false);
		PawnBedYesSleep.SetActive(true);
		anims.SetBool("Talk", true);
	}

	public void StopTalking()
	{
		anims.SetBool("Talk", false);
	}

	public override void Undo()
	{
		PawnBedNoSleep.SetActive(true);
		PawnBedYesSleep.SetActive(false);
		humming.Play();
	}
}
