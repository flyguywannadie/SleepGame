using UnityEngine;
using UnityEngine.UI;

public class InventorySpot : MonoBehaviour
{
	[SerializeField] private Image itemImage;

	public void Populate()
	{
		
	}

	public void Clear()
	{

	}

	public void StartDrag()
	{
		Debug.Log("start Drag");
		itemImage.transform.position = transform.position;
	}

	public void Drag()
	{
		Debug.Log("Drag");
		itemImage.transform.position = Input.mousePosition;
	}

	public void EndDrag()
	{
		Debug.Log("end Drag");
		itemImage.transform.position = transform.position;
	}
}
