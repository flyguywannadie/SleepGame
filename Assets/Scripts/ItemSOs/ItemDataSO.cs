using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemDataSO : ScriptableObject
{
    public PlayerAction itemAction;
    public Sprite itemImage;
}
