using UnityEngine;

public class MainMenuEyeFollow : MonoBehaviour
{
	[SerializeField] private Vector2 lookExtends;
	[SerializeField] private Vector3 lookCenter;

	private void Start()
	{
		transform.position = lookCenter;
	}

	private void Update()
	{
		Vector2 mp = Input.mousePosition;
		mp = (mp * 2) - Camera.main.pixelRect.size;
		float xb = lookExtends.x;
		float yb = lookExtends.y;

		float xratio = xb / Camera.main.pixelWidth;
		float yratio = yb / Camera.main.pixelWidth;

		float newx = Mathf.Clamp(mp.x * xratio, -xb, xb);
		float newy = Mathf.Clamp(mp.y * yratio, -yb, yb);

		transform.position = lookCenter + new Vector3(newx, newy);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(lookCenter, lookExtends * 2);
	}
}
