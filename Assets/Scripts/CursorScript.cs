using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
	[SerializeField] private Animator anims;
	[SerializeField] private RuntimeAnimatorController[] cursorAnimations;
	[SerializeField] private Image visuals;

	private void Awake()
	{
		anims = GetComponent<Animator>();
		visuals = GetComponent<Image>();

		Cursor.visible = false;
	}

	private void Update()
	{
		transform.position = Input.mousePosition;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			anims.SetBool("Interact", true);
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			anims.SetBool("Interact", false);
		}
	}

	public void SetCursor(PlayerAction cursor)
	{
		anims.runtimeAnimatorController = cursorAnimations[(int)cursor];
	}
}
