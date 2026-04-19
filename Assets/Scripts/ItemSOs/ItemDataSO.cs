using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/Item Data")]
public class ItemDataSO : ScriptableObject
{
    public Sprite itemImage;
    public Sprite itemPressed;
    public ActionCursorSO actionCursor;
}
