using UnityEngine;

public class Room1PuzzleScript : MonoBehaviour
{
	[SerializeField] private Animator doorAnims;

	public void Button(int which)
	{
		Debug.Log("Button " + which + " Pressed");

		switch (which)
		{
			case 0:
				break;
			case 1:
				break;
			case 2:
				break;
		}
	}

	public void ButtonUndo(int which)
	{
		Debug.Log("Button " + which + " Undone");

		switch (which)
		{
			case 0:
				break;
			case 1:
				break;
			case 2:
				break;
		}
	}
}
