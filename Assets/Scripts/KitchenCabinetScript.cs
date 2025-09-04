using UnityEngine;

public class KitchenCabinetScript : MonoBehaviour
{
	[SerializeField] private BaseDoorScript leftdoor;
	[SerializeField] private BaseDoorScript rightdoor;

	public void RightDoor()
	{
		if (rightdoor.open)
		{
			rightdoor.Close();
		} else
		{
			rightdoor.Open();
			if (leftdoor.open)
			{
				leftdoor.Close();
				GameManager.instance.AddConditionalUndo(leftdoor.OpenInstant);
			}
		}
	}

	public void LeftDoor()
	{
		if (leftdoor.open)
		{
			leftdoor.Close();
		}
		else
		{
			leftdoor.Open();
			if (rightdoor.open)
			{
				rightdoor.Close();
				GameManager.instance.AddConditionalUndo(rightdoor.OpenInstant);
			}
		}
	}

	public void RightUndo()
	{
		if (rightdoor.open)
		{
			rightdoor.CloseInstant();
		} else
		{
			rightdoor.OpenInstant();
		}
	}

	public void LeftUndo()
	{
		if (leftdoor.open)
		{
			leftdoor.CloseInstant();
		}
		else
		{
			leftdoor.OpenInstant();
		}
	}
}
