using UnityEngine;

[CreateAssetMenu(fileName = "ActionCursor", menuName = "Scriptable Objects/Action Cursor")]
public class ActionCursorSO : ScriptableObject
{
    public PlayerAction itemAction;
    public RuntimeAnimatorController interactAnim;
}
