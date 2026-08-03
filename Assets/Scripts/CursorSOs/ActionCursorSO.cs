using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionCursor", menuName = "Scriptable Objects/Action Cursor")]
public class ActionCursorSO : ScriptableObject
{
    public Sprite cursorUnselect;
    public animFrame[] frames;
    public RuntimeAnimatorController interactAnim;

    [Serializable]
    public struct animFrame
    {
        public Sprite frame;
        public float frameLength;
    }
}
