using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerScript : MonoBehaviour
{
	public static PlayerScript instance { get; private set; }

	[SerializeField] private List<Sprite> headSprites;
	[SerializeField] private SpriteRenderer head;
	[SerializeField] private Animator anims;

	[SerializeField] private Vector3 goToPos;
	//[SerializeField] private List<Vector3> undoLocations;

	[SerializeField] private AudioClip moveSound;
	[SerializeField] private AudioClip slideSound;

	private PlayerAction animationAction;
	private PlayerAction movementForcedAction;
	private PlayerAction queuedForcedAction;

	private float moveSpeed = 1;
	private float lookatDelay = 0;

	[SerializeField] private bool moving = false;
	[SerializeField] private bool animMove = true;
	[SerializeField] private bool stairMovement;

    [SerializeField] private float stairMovementDistance;
    [SerializeField] private Vector3 stairMovementStart;
	[SerializeField] private StairsScript currentActionMover;
    //[SerializeField] private Transform stairMovementFollow;

    private void Awake()
	{
		instance = this;
		SetStairMovement(false, null);
    }

	private void Start()
	{
		goToPos = transform.position;
	}

	private void Update()
	{
		if (GameManager.instance.IsGamePaused())
		{
			if (moving)
			{
				animMove = false;
				moving = false;

				EyeLookAt(goToPos - transform.position);
				
				goToPos = transform.position;

				anims.SetBool("Move", moving);
			}
			return;
		}

		Vector3 look = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		float distance = Vector3.Distance(transform.position, goToPos);

        if (!stairMovement)
		{
            if (moving && distance <= 0.01f)
            {
                animMove = false;
				EndMovement();
            }
            else if (moving)
            {
                look = goToPos - transform.position;
            }

            anims.SetBool("Move", moving);
            anims.SetFloat("Distance", distance);
            anims.SetFloat("Side", Mathf.Clamp((transform.position.x - goToPos.x) / 3.0f, -1.0f, 1.0f));

            if (animMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, goToPos, moveSpeed * Time.deltaTime);
                look = goToPos - transform.position;
            }
        }
		else
		{
            // Might need to attatch the player to different objects for certain action movements
            //if (stairMovementFollow)
            //{
            //	transform.position = stairMovementFollow.transform.position;
            //}

            //         if (moving && distance <= 0.01f)
            //         {
            //             //animMove = false;
            //             //moving = false;
            //             transform.position = goToPos;
            //	if (forcedAction != null)
            //	{
            //		if (forcedAction.GetName() == "Action" || forcedAction.GetName() == "")
            //		{
            //			//GameManager.instance.AddActionToStack(forcedAction);
            //			forcedAction.Execute();
            //		}
            //		else
            //		{
            //			PlayAnimationWithAction(forcedAction);
            //		}
            //		forcedAction = null;
            //	}
            //}
            //         else 
			if (moving)
			{
				look = goToPos - stairMovementStart;
			}

			anims.SetBool("Move", moving);

			if (animMove)
			{
				stairMovementDistance += Time.deltaTime;
				transform.position = Vector3.Lerp(stairMovementStart, goToPos, (stairMovementDistance / moveSpeed));
			}
        }

		EyeLookAt(look);
	}

	public void EyeLookAt(Vector3 look)
	{
		if (lookatDelay > 0.0f)
		{
			lookatDelay -= Time.deltaTime;
			return;
		}
		int lookangle = (int)(Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg) + 180;
		int index = 4;
		if (lookangle > 35 && lookangle <= 125)
		{
			index = 3;
		}
		else if (lookangle > 125 && lookangle <= 180)
		{
			index = 2;
		}
		else if (lookangle > 180 && lookangle <= 245)
		{
			index = 1;
		}
		else if (lookangle > 245 && lookangle <= 295)
		{
			index = 0;
		}
		else if (lookangle > 295 && lookangle <= 360)
		{
			index = 5;
		}
		//Debug.Log(lookangle + " - " + index);
		head.sprite = headSprites[index];
	}

	private void EndMovement()
	{
		lookatDelay = 0.1f;
        moving = false;
        transform.position = goToPos;
        if (movementForcedAction != null)
        {
            if (movementForcedAction.GetName() == "Action" || movementForcedAction.GetName() == "")
            {
                //GameManager.instance.AddActionToStack(forcedAction);
                movementForcedAction.Execute();
            }
            else
            {
                PlayAnimationWithAction(movementForcedAction);
            }
            movementForcedAction = queuedForcedAction;
			queuedForcedAction = null;
        }
    }

	public void StartAnimMove(float speed)
	{
		animMove = true;
		moveSpeed = speed;
		//GameManager.instance.PlaySound(moveSound);
	}

	public void HopSound()
	{
		GameManager.instance.PlaySound(moveSound);
	}

	public void SlideSound()
	{
		GameManager.instance.PlaySound(slideSound);
	}

	public void EndAnimMove()
	{
		animMove = false;
	}

	public void ForcePosition(Vector3 pos)
	{
		transform.position = pos;
		goToPos = pos;
	}

	/// <summary>
	/// Sets the player to move to a given location
	/// Adds a PLayer Movement action to the stack if the player was not already moving
	/// </summary>
	/// <param name="pos">Position to move towards</param>
	public void MovePlayer(Vector3 pos)
	{
		movementForcedAction = null;
		goToPos = new Vector3(pos.x, pos.y, transform.position.z);
		//TryAddMovementUndo();
        StartMove();
    }

	public void StopMoving()
	{
		MovePlayer(transform.position);
	}

	//public void MovePlayerNoUndo(Vector3 pos)
	//{
	//	goToPos = new Vector3(pos.x, pos.y, transform.position.z);
	//	StartMove();
	//}

	/// <summary>
	/// Forces the Player to move then do an action after movement stops
	/// Adds a Player Movement action to the stack
	/// </summary>
	/// <param name="pos">Position to move towards</param>
	/// <param name="action">Action to be done after movement</param>
	public void ForceMovementIntoAction(Vector3 pos, PlayerAction action)
	{
		if (movementForcedAction == null)
		{
			movementForcedAction = action;
		}
		else
		{
			queuedForcedAction = action;
		}
		goToPos = new Vector3(pos.x, pos.y, transform.position.z);
        //TryAddMovementUndo();
        StartMove();
	}

	private void TryAddMovementUndo()
	{
		if (!moving)
		{
			//undoLocations.Add(transform.position);
			//GameManager.instance.AddActionToStack(new UndoableAction("Player Movement", StartMove, UndoMove));
		}
	}

	public void StartMove()
	{
		moving = true;
		if (stairMovement)
		{
			stairMovementDistance = 0;
			stairMovementStart = transform.position;
		}
        lookatDelay = 0.0f;
        //		transform.position = new Vector3(goToPos.x, goToPos.y, 0);
    }

	public void UndoMove()
	{
		//forcedAction = null;
		//if (undoLocations.Count <= 0)
		//{
		//	return;
		//}
		//int index = undoLocations.Count - 1;
		//transform.position = undoLocations[index];
		//goToPos = transform.position;
		//undoLocations.RemoveAt(index);
		//anims.Play("Idle");
	}

	public void ForceIdleAnim()
	{
		//animationAction = null;
		movementForcedAction = null;
		anims.Play("Idle");
	}

	public void PlayAnimation(string anim, bool disableActions = true)
    {
		anims.Play(anim);
        if (disableActions)
        {
			InteractionManager.instance.DisableInteractions();
        }
	}

	public void PlayAnimationWithAction(PlayerAction action)
	{
		animationAction = action;
		anims.Play(action.GetName());
		InteractionManager.instance.DisableInteractions();
	}

	public void ActionAnimationDone()
	{
		if (!GameManager.instance.IsGamePaused())
		{
			InteractionManager.instance.EnableInteractions();
			if (stairMovement)
			{
				EndMovement();
            }
		}
	}

	public void DoAnimationAction()
	{
		animationAction.Execute();
	}

	public Vector3 GetPlayerPos()
	{
		return transform.position;
	}

	public bool GetStairMovement()
	{
		return stairMovement;
	}

	public void SetStairMovement(bool sm, StairsScript stairs)
	{
		stairMovement = sm;
		currentActionMover = stairs;
    }

	public void TryExit(Vector3 exitpos)
	{
		currentActionMover.TryExit(exitpos);
	}
}
