using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySpot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	[SerializeField] private Image itemImage;
	[SerializeField] private ItemDataSO myitem;

	//[SerializeField] private Vector3 itemStartPos;
	[SerializeField] private PlayerAction previousHoverAction;

	private void Start()
	{
		//itemStartPos = itemImage.transform.position;
	}

	public bool hasItem()
	{
		return myitem != null;
	}

	public void Populate(ItemDataSO item)
	{
		myitem = item;
		itemImage.gameObject.SetActive(true);
		itemImage.sprite = myitem.itemImage;
	}

	public void Clear()
	{
		myitem = null;
		itemImage.gameObject.SetActive(false);
	}

	//public void StartDrag()
	//{
	//	if (!InteractionManager.instance.AreActionsEnabled())
	//	{
	//		return;
	//	}
	//	Debug.Log("start Drag");
	//	itemImage.transform.position = itemStartPos;
	//	itemImage.enabled = false;
	//	InteractionManager.instance.ChangeAction(myitem.itemAction);
	//}

	//public void Drag()
	//{
	//	if (!InteractionManager.instance.AreActionsEnabled())
	//	{
	//		return;
	//	}
	//	Debug.Log("Drag");
	//	itemImage.transform.position = Input.mousePosition;
	//}

	//public void EndDrag()
	//{
	//	if (!InteractionManager.instance.AreActionsEnabled())
	//	{
	//		return;
	//	}
	//	StopDragging();
	//}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!InteractionManager.instance.AreActionsEnabled() || !(eventData.button == PointerEventData.InputButton.Left) || myitem == null)
		{
			return;
		}
		Debug.Log("start Drag");
		itemImage.enabled = false;
		InteractionManager.instance.ChangeAction(myitem.itemAction);
	}

	public void OnDrag(PointerEventData eventData)
	{
	}
	
	public void OnEndDrag(PointerEventData eventData)
	{
		if (!InteractionManager.instance.AreActionsEnabled() || !(eventData.button == PointerEventData.InputButton.Left) || myitem == null)
		{
			return;
		}
		Debug.Log("end Drag");
		itemImage.enabled = true;
		InteractionManager.instance.ChangeActionPrev();
	}
}
