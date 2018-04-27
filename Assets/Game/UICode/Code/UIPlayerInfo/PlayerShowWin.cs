using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerShowWin : UISubWindow<UIPlayerInfoWindow, UIPlayerInfoController>
{
    #region ui control name define
    private const string ModelRoot = "/ModelRoot";
    private const string ModelCamera = "/Camera";
    private const string ModelTexture = "/ModelTexture";
    private const string DragTexture = "/DragTexture";
    #endregion

    private Transform modelRoot;
    private Camera modelCamera;
    private ExUITexture modelTexture;
    private UIPointerListener modelListener;

    private RenderTexture renderTexture;

    public override void Initial(UIPlayerInfoWindow window, UIPlayerInfoController controller, string topPath = "")
    {
        base.Initial(window, controller, topPath);
        modelRoot = this.FindTransform(ModelRoot);
        modelCamera = this.GetComponent<Camera>(ModelCamera);
        modelListener = this.GetComponent<UIPointerListener>(DragTexture);
        modelListener.OnDragCallBack = OnDrag;
        modelTexture = this.GetComponent<ExUITexture>(ModelTexture);
        renderTexture = RenderTexture.GetTemporary(800, 800, 0);
        modelCamera.forceIntoRenderTexture = true;
        modelCamera.targetTexture = renderTexture;
        modelTexture.texture = renderTexture;
        modelTexture.color = new Color(modelTexture.color.r, modelTexture.color.g, modelTexture.color.b,1);
    }

    private void OnDrag(int id, object vec)
    {
        PointerEventData data = vec as PointerEventData;
        if (_avatar != null)
        {
            _avatar.Root.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, _avatar.Root.transform.localRotation.eulerAngles.y - data.delta.x, 0.0f));
        }
    }

    public void HideModel()
    {
        modelCamera.enabled = false;
    }

    public override void Refresh()
    {
        modelCamera.enabled = true;
        ShowAvatar();
    }

    Avatar _avatar = null;
    public void ShowAvatar()
    {
        if (_avatar == null)
        {
            VisualHeroStruct visualInfo = ViSealedDB<VisualHeroStruct>.Data(1);
            SimpleAvatarStruct avatarInfo = visualInfo.Avatar.Data;
            _avatar = new Avatar();
            _avatar.LoadCallback = this._OnAvatarLoaded;
            AvatarCreator.Create(_avatar, avatarInfo.BodyResource.Resource, 1.0f, avatarInfo.PartResource);
        }
        else
        {
            _OnAvatarLoaded(_avatar);
        }
    }

    private void _OnAvatarLoaded(Avatar avatar)
    {
        int id = -1;
        Transform parent = modelRoot;
        avatar.RootTran.parent = parent;
        UnityAssisstant.SetLayerRecursively(avatar.Root,(int)UnityLayer.UI_Model);
        avatar.Root.name = "HeroAvatar";
        avatar.RootTran.localPosition = new Vector3(0, -220, 0);
        avatar.RootTran.localRotation = Quaternion.Euler(0, 180, 0);
        avatar.RootTran.localScale = new Vector3(150,150,150);
        avatar.PlayActionAnim(AnimationData.Idle, true);
        avatar.ChangeUIShander();
    }
}