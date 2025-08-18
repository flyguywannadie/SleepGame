using UnityEngine;

public class CameraScript : MonoBehaviour
{
	[SerializeField] private Transform follow;
	[SerializeField] private CameraTrack currentTrack;

	public void SetCameraTrack(CameraTrack track)
	{
		currentTrack = track;
	}

	private void Update()
	{
		float clampedx = currentTrack.ClampToValueTrack(follow.position.x);
		transform.position = new Vector3(clampedx, currentTrack.transform.position.y, transform.position.z);
	}
}
