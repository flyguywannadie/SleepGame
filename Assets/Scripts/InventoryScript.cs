using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryScript : MonoBehaviour
{
	public static InventoryScript instance { get; private set; }

	[SerializeField] private InventorySpot activeSpot;
	[SerializeField] private List<InventorySpot> inventorySlots;
	//[SerializeField] private ItemDataSO test;
	[SerializeField] private List<InventoryUndo> undos = new List<InventoryUndo>();

	private class InventoryUndo
	{
		public int spot;
		public bool addItem;
		public ItemDataSO item;

		public InventoryUndo(int spot, bool addItem, ItemDataSO item) {
			this.spot = spot;
			this.addItem = addItem;
			this.item = item;
		}
	}

	private void Awake()
	{
		instance = this;
	}

	public bool CanAddItem()
	{
		foreach (InventorySpot item in inventorySlots)
		{
			if (!item.hasItem())
			{
				return true;
			}
		}
		return false;
	}

	public void AddItem(ItemDataSO item)
	{
		if (!CanAddItem())
		{
			return;
		}

		for (int i = 0; i < inventorySlots.Count; i++)
		{
			if (!inventorySlots[i].hasItem())
			{
				inventorySlots[i].Populate(item);
				undos.Add(new InventoryUndo(i, true, item));
				return;
			}
		}
	}

	public void UseItem()
	{
		undos.Add(new InventoryUndo(inventorySlots.IndexOf(activeSpot), false, activeSpot.GetItem()));
		activeSpot.Clear();
	}

	public void SetActiveInventorySpot(InventorySpot i)
	{
		activeSpot = i;
	}

	public void Undo()
	{
		InventoryUndo u = undos[undos.Count - 1];
		if (u.addItem)
		{
			inventorySlots[u.spot].Clear();
		} else
		{
			inventorySlots[u.spot].Populate(u.item);
		}
		undos.Remove(u);
	}

	//private void Update()
	//{
	//	if (Input.GetKeyDown(KeyCode.I))
	//	{
	//		AddItem(test);
	//	}
	//	if (Input.GetKeyDown(KeyCode.O))
	//	{
	//		RemoveItem();
	//	}
	//}
}
