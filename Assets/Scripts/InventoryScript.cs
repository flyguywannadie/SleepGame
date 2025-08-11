using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
	[SerializeField] private int itemCount = 0;
	[SerializeField] private InventorySpot inventorySlots;
	[SerializeField] private ItemDataSO test;

	public bool CanAddItem()
	{
		return !inventorySlots.hasItem();
	}

	public void AddItem(ItemDataSO item)
	{
		if (!CanAddItem())
		{
			return;
		}

		inventorySlots.Populate(item);
	}

	public void RemoveItem()
	{
		inventorySlots.Clear();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			AddItem(test);
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			RemoveItem();
		}
	}
}
