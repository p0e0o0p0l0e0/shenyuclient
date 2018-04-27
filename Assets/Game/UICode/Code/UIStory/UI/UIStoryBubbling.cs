using UnityEngine;

public class UIStoryBubbling : UIStoryBase
{
    #region ui control name define
    private const string DialogText = "/DialogText";
    #endregion
    private Transform _prefabTrans = null;

    public override void Initial(UIStoryWindow window, string topPath)
    {
        base.Initial(window, topPath);
        Open();
        _prefabTrans = this.GetComponent<Transform>(DialogText);
        _prefabTrans.SetActive(false);
    }

    public override void ShowUI(StoryFunctionData data, VoidDelegate callBack)
    {

    }

    public GameObject CreateBubblingChild()
    {
        if (_prefabTrans == null)
            return null;

        GameObject bubbling = GameObject.Instantiate(_prefabTrans.gameObject);
        bubbling.transform.SetParent(this._rootTran);
        bubbling.transform.localPosition = Vector3.zero;
        bubbling.transform.localScale = Vector3.one;
        return bubbling;
    }
}
