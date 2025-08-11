using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
	[SerializeField] private Animator pauseAnim;
	[SerializeField] private bool paused;
	[SerializeField] private bool animFinished = false;

	private void Start()
	{
		InteractionManager.instance.DisableInteractions();
	}

	public void PauseGame()
	{
		if (animFinished)
		{
			pauseAnim.SetBool("Pause", true);
			InteractionManager.instance.DisableInteractions();
			PlayerScript.instance.PlayActionAnimation("CloseEye", null);
			paused = true;
			animFinished = false;
		}
	}

	public void UnpauseGame()
	{
		if (animFinished)
		{
			pauseAnim.SetBool("Pause", false);
			PlayerScript.instance.PlayActionAnimation("OpenEye", null);
			paused = false;
			animFinished = false;
		}
	}

	public void FinishAnim()
	{
		animFinished = true;
	}

	public void UnpauseFinish()
	{
		InteractionManager.instance.EnableInteractions();
	}

	public void FinishBeginning()
	{
		FinishAnim();
		InteractionManager.instance.EnableInteractions();
	}

	public bool IsGamePaused()
	{
		return paused;
	}

	public void BeginningOpenEye()
	{
		PlayerScript.instance.PlayActionAnimation("OpenEye", null);
	}
}
