using UnityEngine;
using UnityEngine.Rendering;

public class StairsScript : BaseWalkupAction
{
    public StairStepScript[] mySteps;
    public int desiredStep;
    public int currentStep;

    public Vector3 exitWalkPosition;
    public bool goingtoExit;

    //[SerializeField] private Transform stairFollow;

    private void Start()
    {
        for (int i = 0; i < mySteps.Length; i++)
        {
            mySteps[i].InitializeStep(this, i);
        }
    }

    public void GetPlayerOnSteps(int step)
    {
        currentStep = 0;
        desiredStep = step;
        DoTheAction();
    }

    public void MovePlayerToStep(int step)
    {
        exitWalkPosition = Vector3.zero;
        goingtoExit = false;
        desiredStep = step;
        ChainStep();
    }

    public void TryExit(Vector3 exitpos)
    {
        exitWalkPosition = exitpos;
        goingtoExit = true;
        desiredStep = 0;
        ChainStep();
    }

    private void Update()
    {
        
    }

    public void ChainStep()
    {
        if (currentStep < desiredStep)
        {
            currentStep++;
            PlayerScript.instance.ForceMovementIntoAction(mySteps[currentStep].stepLocation.position, new PlayerAction(ChainStep));
        }
        else if (currentStep > desiredStep)
        {
            currentStep--;
            PlayerScript.instance.ForceMovementIntoAction(mySteps[currentStep].stepLocation.position, new PlayerAction(ChainStep));
        }
        else
        { 
            if (goingtoExit)
            {
                PlayerScript.instance.ForceMovementIntoAction(animLineupLocation.position, new PlayerAction(ExitAction));
                PlayerScript.instance.PlayAnimation("StairStep", false);
            }
            return; 
        }
        PlayerScript.instance.PlayAnimation("StairStep", false);
    }

    public void ExitAction()
    {
        PlayerScript.instance.SetStairMovement(false, null);
        PlayerScript.instance.MovePlayer(exitWalkPosition);
        goingtoExit = false;
    }

    protected override void Execute()
    {
        //Debug.Log("Stairs Get On");
        //PlayerScript.instance.ForcePosition(mySteps[0].stepLocation.position);
        PlayerScript.instance.SetStairMovement(true, this);
        if (desiredStep != currentStep)
        {
            PlayerScript.instance.ForceMovementIntoAction(mySteps[0].stepLocation.position, new PlayerAction(ChainStep));
        }
        else
        {
            PlayerScript.instance.MovePlayer(mySteps[0].stepLocation.position);
        }
        PlayerScript.instance.PlayAnimation("StairStep", false);
    }

    public override void DoTheAction()
    {
        if (Vector2.Distance(PlayerScript.instance.GetPlayerPos(), animLineupLocation.position) > 0.01f)
        {
            PlayerScript.instance.ForceMovementIntoAction(animLineupLocation.position, new PlayerAction(Execute));
            return;
        }
        PlayerScript.instance.PlayAnimationWithAction(new PlayerAction(Execute));
    }
}
