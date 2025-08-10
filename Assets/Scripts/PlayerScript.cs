using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public static PlayerScript instance { get; private set; }

	[SerializeField] private List<Sprite> headSprites;
	[SerializeField] private SpriteRenderer head;
	[SerializeField] private Animator anims;

	[SerializeField] private Vector3 goToPos;
	[SerializeField] private List<Vector3> undoLocations;

	private UndoableAction animationAction;

	private float moveSpeed = 1;

	private bool moving = false;
	private bool animMove = true;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		goToPos = transform.position;
	}

	private void Update()
	{
		if (!InteractionManager.instance.AreActionsEnabled())
		{
			return;
		}

		Vector3 look = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		float distance = Vector3.Distance(transform.position, goToPos);
		if (moving && distance <= 0.01f)
		{
			animMove = false;
			moving = false;
			transform.position = goToPos;
		} else if (moving)
		{
			look = goToPos - transform.position;
		}

		anims.SetBool("Move", moving);
		anims.SetFloat("Distance", distance);
		anims.SetFloat("Side", Mathf.Clamp((transform.position.x - goToPos.x)/3.0f,-1.0f,1.0f));

		if (animMove)
		{
			transform.position = Vector3.MoveTowards(transform.position, goToPos, moveSpeed * Time.deltaTime);
		}

		int lookangle = (int)(Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg) + 180;
		int index = 4;
		if (lookangle > 35 && lookangle <= 125)
		{
			index = 3;
		} else if (lookangle > 125 && lookangle <= 180)
		{
			index = 2;
		} else if (lookangle > 180 && lookangle <= 245)
		{
			index = 1;
		} else if (lookangle > 245 && lookangle <= 295)
		{
			index = 0;
		} else if (lookangle > 295 && lookangle <= 360)
		{
			index = 5;
		}
		//Debug.Log(lookangle + " - " + index);
		head.sprite = headSprites[index];
	}

	public void StartAnimMove(float speed)
	{
		animMove = true;
		moveSpeed = speed;
	}

	public void EndAnimMove()
	{
		animMove = false;
	}

	public void ForcePlayerMovement(Vector3 pos)
	{
		goToPos = new Vector3(pos.x, pos.y, transform.position.z);
		if (!moving)
		{
			undoLocations.Add(transform.position);
			GameManager.instance.AddActionToStack(new UndoableAction("Player Movement",StartMove, UndoMove));
		}
	}

	public void StartMove()
	{
		moving = true;
//		transform.position = new Vector3(goToPos.x, goToPos.y, 0);
	}

	public void UndoMove()
	{
		if (undoLocations.Count <= 0)
		{
			return;
		}
		int index = undoLocations.Count - 1;
		transform.position = undoLocations[index];
		goToPos = transform.position;
		undoLocations.RemoveAt(index);
		anims.Play("Idle");
	}

	public void PlayActionAnimation(string anim, UndoableAction action)
	{
		animationAction = action;
		anims.Play(anim);
		InteractionManager.instance.DisableInteractions();
	}

	public void ActionAnimationDone()
	{
		InteractionManager.instance.EnableInteractions();
	}

	public void DoAnimationAction()
	{
		GameManager.instance.AddActionToStack(animationAction);
	}

	public Vector3 GetPlayerPos()
	{
		return transform.position;
	}
}
