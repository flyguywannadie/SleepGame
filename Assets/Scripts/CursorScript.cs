using System.Buffers;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.Progress;

public class CursorScript : MonoBehaviour
{
	[SerializeField] private Animator anims;
	//[SerializeField] private RuntimeAnimatorController[] cursorAnimations;
	[SerializeField] private ActionCursorSO currentCursor;
	//[SerializeField] private ActionCursorSO tempCursor;
	[SerializeField] private ActionableItem whatIAmSelecting;
    [SerializeField] private Image visuals;

    [SerializeField] private float frameTime;
    [SerializeField] private int currentCursorFrame;

	private void Awake()
	{
		//anims = GetComponent<Animator>();
		visuals = GetComponent<Image>();

		Cursor.visible = false;
		//anims.StopPlayback();
	}

	private void Update()
	{
		transform.position = Input.mousePosition;

		//if (Input.GetKeyDown(KeyCode.Space))
		//{
		//	anims.SetBool("Interact", true);
		//}
		//if (Input.GetKeyUp(KeyCode.Space))
		//{
		//	anims.SetBool("Interact", false);
		//}
//		bool works = false;

        Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		
		if (whatIAmSelecting == null)
		{
            if (hit != null)
            {
                ActionableItem[] actionItem = hit.gameObject.GetComponents<ActionableItem>();
                foreach (ActionableItem item in actionItem)
                {
                    if (item.AreActionsCorrect())
                    {
                        //SetTempCursor(item.getCursor());
						SetWhatIAmOverlapping(item);
                        //works = true;
                    }
                }
            }
            //else if (tempCursor != null)
            //{
            //    //SetTempCursor(null);
            //}
        }
		else if (whatIAmSelecting != null)
		{
			if (hit == null)
			{
				SetWhatIAmOverlapping(null);
			}
			else if (hit.gameObject != whatIAmSelecting.gameObject)
			{
                SetWhatIAmOverlapping(null);
                //Debug.Log(hit.gameObject.name);
                ActionableItem[] actionItem = hit.gameObject.GetComponents<ActionableItem>();
				foreach (ActionableItem item in actionItem)
				{
					if (item.AreActionsCorrect())
					{
						//SetTempCursor(item.getCursor());
						SetWhatIAmOverlapping(item);
						//works = true;
					}
				}
			}
		}

		PlayInterAnim();
	}

	public void SetWhatIAmOverlapping(ActionableItem overlap)
	{
		whatIAmSelecting = overlap;
		if (overlap)
		{
	        Debug.Log(overlap.gameObject.name);
            frameTime = 0;
            currentCursorFrame = 0;

			if (whatIAmSelecting.getCursor())
			{
				visuals.sprite = whatIAmSelecting.getCursor().frames[currentCursorFrame].frame;
			}
			else
			{
				visuals.sprite = currentCursor.frames[currentCursorFrame].frame;
			}
		} else
		{
			Debug.Log("Null");
			frameTime = 0;
			currentCursorFrame = 0;
            visuals.sprite = currentCursor.cursorUnselect;
        }
    }

	public void PlayInterAnim()
	{
		if (whatIAmSelecting == null)
		{
			return;
		}

		ActionCursorSO usedCursor = currentCursor;
		if (whatIAmSelecting.getCursor())
		{
			usedCursor = whatIAmSelecting.getCursor();
		}

		//anims.SetBool("Interact", works);
		//if (usedCursor.cursorUnselect == null || usedCursor.frames.Length == 0)
		//{
		//	return;
		//}

		if (whatIAmSelecting.AreActionsCorrect())
		{
			frameTime += Time.deltaTime;
			if (frameTime >= usedCursor.frames[currentCursorFrame].frameLength)
			{
				frameTime = 0;
				currentCursorFrame += 1;
				if (currentCursorFrame >= usedCursor.frames.Length)
				{
					currentCursorFrame = 0;
				}
				visuals.sprite = usedCursor.frames[currentCursorFrame].frame;
			}
		}
	}

	public void SetCursor(ActionCursorSO cursor)
	{
		if (cursor == null)
		{
			return;
		}
		currentCursor = cursor;
		SetWhatIAmOverlapping(null);
        //anims.runtimeAnimatorController = currentCursor.interactAnim;
    }
	
	public void SetTempCursor(ActionCursorSO cursor)
	{
        //tempCursor = cursor;
    }

	public void HideCursor()
	{
		visuals.enabled = false;
		Cursor.visible = true;
	}

	public void ShowCursor()
	{
		visuals.enabled = true;
		Cursor.visible = false;
	}
}
