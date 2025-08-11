using UnityEngine;

public class StartingAnimation : MonoBehaviour
{
	[SerializeField] private Animator anims;

	public void StartGame()
	{
		anims.Play("Start");
	}

	public void GoToMainGame()
	{
		GameManager.instance.LoadScene("GameScene");
	}
}
