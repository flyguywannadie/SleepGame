using UnityEngine;

public class AnimSoundPlayer : MonoBehaviour
{
	[SerializeField] private AudioClip sound;

	public void PlaySound()
	{
		GameManager.instance.PlaySound(sound);
	}
}
