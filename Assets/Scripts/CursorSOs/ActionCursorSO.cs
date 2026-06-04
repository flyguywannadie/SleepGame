using UnityEngine;

[CreateAssetMenu(fileName = "ActionCursor", menuName = "Scriptable Objects/Action Cursor")]
public class ActionCursorSO : ScriptableObject
{
    public CursorAction itemAction;
    public RuntimeAnimatorController interactAnim;
}
