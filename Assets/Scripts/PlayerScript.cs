using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	[SerializeField] private List<Sprite> headSprites;
	[SerializeField] private SpriteRenderer head;

	private void Update()
	{
		Vector3 look = Camera.main.ScreenToWorldPoint(Input.mousePosition) - head.transform.position;
		int lookangle = (int)(Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg) + 180 + 22;
		int index = (lookangle)/45;
		//Debug.Log(lookangle + " - " + index);
		if (lookangle >= 360)
		{
			index = 0;
		}
		head.sprite = headSprites[index];
	}
}
