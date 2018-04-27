using UnityEngine;
using System.Collections;

/********************************************************************
	created:	2017/01/10
	created:	10:1:2017   12:08
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\StoryFunAnimation.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts\
	file base:	StoryFunAnimation
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/
public class StoryFunAnimation : StoryFunBase
{
    private StoryFunctionAimationData _animationData;

    public override void Run(StoryFunctionData data, VoidDelegate callBack)
    {
        base.Run(data, callBack);
        _animationData = data.animationData;

        PlayAction();
    }
    /// <summary>
    /// 播放动作
    /// </summary>
    public void PlayAction()
    {
        IStoryCharacter character = StoryManager.GetInstance.GetCharacter(_animationData.roleData);
        
        if (character == null)
        {
            return;
        }
        StoryRoleActionData roleActionData = _animationData.roleActionData;
        if (roleActionData.skillID > 0)
            character.PlaySkill(roleActionData.skillID, null, 0, roleActionData.hitID, EndCallBack);
        else
        {
            if (roleActionData.animName.IsNotNullOrEmpty())
            {
                character.Play(roleActionData.animName);
                UConsole.Log("PlayAction:" + roleActionData.animName);
            }
            EndCallBack();
        }
    }

    public override void Stop()
    {

    }
}
