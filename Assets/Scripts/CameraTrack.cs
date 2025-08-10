using UnityEngine;

public class CameraTrack : MonoBehaviour
{
	[SerializeField] private float min;
	[SerializeField] private float max;

	public float ClampToValueTrack(float x)
	{
		float myx = transform.position.x;
		return Mathf.Clamp(x, myx + min, myx + max);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawCube(transform.position + new Vector3(min + max, 0.0f, 0.0f), new Vector3(max - min, 0.2f, 0.0f));
	}
}
