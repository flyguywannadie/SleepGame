using UnityEngine;

public class StairStepScript : ActionableItem
{
    private StairsScript stairs;

    public Transform stepLocation;
    public int stepNum;

    public void InitializeStep(StairsScript s, int number)
    {
        this.stairs = s;
        stepNum = number;
    }

    public override void DoTheAction()
    {
        if (!PlayerScript.instance.GetStairMovement())
        {
            stairs.GetPlayerOnSteps(stepNum);
            return;
        }
        base.DoTheAction();
    }

    protected override void Execute()
    {
        //Debug.Log("Stairs stepping");
        //PlayerScript.instance.ForcePosition(stepLocation.position);
        stairs.MovePlayerToStep(stepNum);
    }
}
