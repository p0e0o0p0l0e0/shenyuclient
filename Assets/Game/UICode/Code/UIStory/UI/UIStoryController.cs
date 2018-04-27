using UnityEngine;

public class UIStoryController : UIController<UIStoryController, UIStoryWindow>
{
    public override void Show()
    {
        base.Show();
    }
    public override void Hide()
    {
        base.Hide();
    }
    public void ShowUI(StoryFunctionData.FUCTION_TYPE type, StoryFunctionData data, VoidDelegate callBack)
    {
        if (this.IsShow)
            this._mWinHandler.ShowUI(type,data, callBack);
    }
    public void CloseUI(StoryFunctionData.FUCTION_TYPE type)
    {
        if (this.IsShow)
            this._mWinHandler.CloseUI(type);
    }
    public void Stop(StoryFunctionData.FUCTION_TYPE type)
    {
        if (this.IsShow)
            this._mWinHandler.Stop(type);
    }

    public void SetLayer(int layer)
    {
        if (_mWinHandler.IsNotNull())
        {
            _mWinHandler.SetLayer(layer);
        }
    }
    
    public GameObject CreateBubblingChild()
    {
        return  this._mWinHandler.CreateBubblingChild();
    }
}

