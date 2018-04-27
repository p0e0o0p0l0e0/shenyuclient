using System.Collections.Generic;
using UnityEngine;

public class UIGoalController : UIController<UIGoalController, UIGoalWindow>
{

    public override void Show()
    {
        base.Show();
        
        UpdateGoalList(GoalManager.GetInstance.GoalList);
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
    public void UpdateGoalArray(GoalObject[] goalArray)
    {
        if (this.IsShow)
            this._mWinHandler.UpdateGoalArray(goalArray);
    }
    public void KillGoalItem(uint id)
    {
        if (this._mWinHandler != null)
        {
            this._mWinHandler.KillGoalItem(id);
        }
    }
    public void ShowGoalCompleteUI()
    {
        if (this.IsShow)
            this._mWinHandler.ShowGoalCompleteUI();
    }

    public void ClickGoalItem(uint id)
    {
        GoalManager.GetInstance.DoGoal(id);
    }
    private bool _isCreating;
    public void OnBtnCreateTeamClick()
    {
        if (!_isCreating)
        {
            _isCreating = true;
            PartyInstance.CreateParty(() =>
            {
                _isCreating = false;
            });
        }
    }
    public void OnToggleTeamClick(bool isShowTeam)
	{
		if (isShowTeam)
		{
			UIManagerUtility.ShowTeamList();
			return;
		}
		//if (isShowTeam)
		//{
		//	UIManagerUtility.ShowTeam();
		//}
		
	}

	public void OnInviteBtnClick()
	{
		UIManagerUtility.ShowTeamInviteFriend();
	}
}
