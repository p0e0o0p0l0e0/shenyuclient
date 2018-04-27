using UnityEngine;
using UnityEngine.UI;


public class UIMapComponent : UIWindowComponent<UIMiniMapWindow, UIMiniMapController>
{

    #region ui control name define
    private const string BackTexture = "/Back";   
    private const string SpaceName = "/SpaceName";
    #endregion

    protected ExUITexture _mapTexture = null;
    
    protected UIMapBase _mapCtrl = null;
    private Text _spaceName = null;
    //private ViTimeNode4 _updateCD = new ViTimeNode4();
    protected bool _isActive = true;

    public override void Initial(UIMiniMapWindow window, string topPath)
    {
        base.Initial(window, topPath);
        _mapTexture = this.GetComponent<ExUITexture>(BackTexture);
        
        _spaceName = this.GetComponent<Text>(SpaceName);
    }
    public virtual void CreateMap(Vector2 terrianSize, Vector2 terrianCenter, Vector2 uimapSize, bool isRevertDir, float offsetAngle, float directionAngle)
    {
        _mapCtrl = UIMapBase.CreateMap(terrianSize, terrianCenter, uimapSize, isRevertDir, offsetAngle, directionAngle);

    }
    public void SetBackTex(Texture2D tex)
    {
        _mapTexture.texture = tex;
        _mapTexture.SetNativeSize();
    }
    public virtual void SetVisible(bool isVisible)
    {
        this._rootTran.gameObject.SetActive(isVisible);
        _isActive = isVisible;
        //if (_isActive)
        //    _updateCD.Start(ViTimerRealInstance.Timer, 5, _OnTimeOut);
        //else
        //    _updateCD.Detach();
    }
    //private void _OnTimeOut(ViTimeNodeInterface node)
    //{
    //    if (CellHero.LocalHero != null)
    //    {
    //        Transform player = CellHero.LocalHero.VisualBody.RootTran;
    //        UpdatePosition(player);
    //    }

    //}
    //private void UpdatePosition(Transform target)
    //{
    //    _playerTran.rotation = _mapCtrl.ConvertRotation(target.rotation);
    //    _mapTexture.transform.localPosition = -_mapCtrl.ConvertPosition(target.position);
    //}
    public void SetReverseDirection(bool isReverse)
    {
        _mapCtrl.IsDirectionInvert = isReverse;
    }
    public override void Dispose()
    {
        //_updateCD.Detach();
        //_updateCD = null;
        _mapTexture = null;
        base.Dispose();
    }
    public void SetMapName(string name)
    {
        _spaceName.text = name;
    }
}
