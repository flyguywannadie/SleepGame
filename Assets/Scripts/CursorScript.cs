using System.Buffers;
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

		//Cursor.visible = false;
	}

	private void Update()
	{
		transform.position = Input.mousePosition;

		//if (Input.GetKeyDown(KeyCode.Space))
		//{
		//	anims.SetBool("Interact", true);
		//}
		//if (Input.GetKeyUp(KeyCode.Space))
		//{
		//	anims.SetBool("Interact", false);
		//}
		bool works = false;

		Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		if (hit != null)
		{
			ActionableItem[] actionItem = hit.gameObject.GetComponents<ActionableItem>();
			foreach (ActionableItem item in actionItem)
			{
				if (item.AreActionsCorrect())
				{
					works = true;
				}
			}
		} 

		SetInteractAnim(works);
	}

	public void SetInteractAnim(bool works)
	{
		anims.SetBool("Interact", works);
	}

	public void SetCursor(PlayerAction cursor)
	{
		anims.runtimeAnimatorController = cursorAnimations[(int)cursor];
	}

	public void HideCursor()
	{
		visuals.enabled = false;
	}

	public void ShowCursor()
	{
		visuals.enabled = true;
	}
}
