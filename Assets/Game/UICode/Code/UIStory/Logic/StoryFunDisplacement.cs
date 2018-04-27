using UnityEngine;
using System.Collections;

/********************************************************************
	created:	2017/01/10
	created:	10:1:2017   12:08
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\StoryFunDisplacement.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts\
	file base:	StoryFunDisplacement
	file ext:	cs
	author:		zlj
	
	purpose:	位移功能
*********************************************************************/
public class StoryFunDisplacement : StoryFunBase
{
    private StoryFunctionDisplacementData _displacementData;

    public override void Run(StoryFunctionData data, VoidDelegate callBack)
    {
        base.Run(data, callBack);
        _displacementData = data.displacementData;

        _OnMoveCharactorPositon();
    }

    public override void Stop()
    {
        
    }
    /// <summary>
    /// 移动人物位置
    /// </summary>
    /// <param name="_data"></param>
    /// <param name="_callBack"></param>
    private void _OnMoveCharactorPositon()
    {
        IStoryCharacter role = StoryManager.GetInstance.GetCharacter(_displacementData.roleData);

        if (role != null)
        {
            if (_displacementData.moveSpeed > 0)
            {
                UConsole.Log("[人物移动] 移动前 SetPos:" + _displacementData.position + ",current position" + role.transform.position);
                role.MoveTo(_displacementData.position, (obj) => {
                    UConsole.Log("[人物移动] 移动后 SetPos:" + _displacementData.position + ",current position" + role.transform.position);
                    MoveEnd(role); });
            }
            else
            {
                UConsole.Log("[人物移动] 设置前 SetPos:" + _displacementData.position + ",current position" + role.transform.position);
                role.SetPosition(_displacementData.position);
                UConsole.Log("[人物移动] 设置后 SetPos:" + _displacementData.position + ",current position" + role.transform.position);
                MoveEnd(role);
            }
        }
        else
        {
            EndCallBack();
        }
    }
    private void MoveEnd(IStoryCharacter character)
    {
        //人物旋转朝向,角度制转弧度制
        character.SetYaw(_displacementData.angle.y / 180 * 3.14f);
       EndCallBack();
    }
}
