using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventorySpot : ActionButton
{
	[SerializeField] private ItemDataSO myitem;

	public bool hasItem()
	{
		return myitem != null;
	}

	public void Populate(ItemDataSO item)
	{
		myitem = item;
		visuals.gameObject.SetActive(true);
		action = item.itemAction;
		UnPressed = item.itemImage;
		Pressed = item.itemPressed;
		UnPress();
	}

	public override void Press()
	{
		if (myitem == null)
		{
			return;
		}
		InventoryScript.instance.SetActiveInventorySpot(this);
		base.Press();
	}

	public override void UnPress()
	{
		if (myitem == null)
		{
			return;
		}
		base.UnPress();
	}

	public void Clear()
	{
		myitem = null;
		UnPressed = null;
		Pressed = null;
		visuals.gameObject.SetActive(false);
	}

	public ItemDataSO GetItem()
	{
		return myitem;
	}
}
