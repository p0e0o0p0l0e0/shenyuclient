using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIGoalDetailsController :  UIController<UIGoalDetailsController, UIGoalDetailsWindow>
{

    public override void Show()
    {
        base.Show();

        UpdateGoalList(GoalManager.GetInstance.GetGoalDetailList());
    }
    public override void Hide()
    {
        base.Hide();
    }
    public void UpdateGoalList(List<GoalObject> goalList)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateGoalList(goalList);
    }
    public void DoGoal(uint goalID)
    {
        GoalManager.GetInstance.DoGoal(goalID);
    }
}
