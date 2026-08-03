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
        itemAction = item.itemAction;
		UnPressed = item.itemImage;
		Pressed = item.itemPressed;
		defaultCursor = item.defaultCursor;
		UnPress();
	}

	public override void Press()
	{
		if (myitem == null)
		{
			return;
		}
		InventoryScript.instance.SetActiveInventorySpot(this, myitem.removeOption);
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
		defaultCursor = null;
		visuals.gameObject.SetActive(false);
	}

	public ItemDataSO GetItem()
	{
		return myitem;
	}
}
