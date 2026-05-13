using UnityEngine;

public enum RemoveItemOption
{
    Trash = 0,
    Drop = 1,
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/Item Data")]
public class ItemDataSO : ScriptableObject
{
    public RemoveItemOption removeOption;

    public Sprite itemImage;
    public Sprite itemPressed;
    public ActionCursorSO actionCursor;
}
