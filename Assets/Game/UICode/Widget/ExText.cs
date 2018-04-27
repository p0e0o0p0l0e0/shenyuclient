using UnityEngine;
using UnityEngine.UI;

public class ExText : Text
{
    [SerializeField] public string FormateId = string.Empty;
    private Color _oldTextColor = Color.white;
    private Color GrayCol = new Color(51f / 255, 51f / 255, 51f / 255, 1);
    private bool _isGray = false;

#if UNITY_EDITOR
    void Reset()
    {
        font = UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.Font>(
            "Assets/UIResource/Font/fangzhengzhunyuan_GBK.ttf");
        alignment = TextAnchor.MiddleCenter;
        raycastTarget = false;
        horizontalOverflow = HorizontalWrapMode.Overflow;
        verticalOverflow = VerticalWrapMode.Overflow;
    }
#endif
    public void SetGray(bool isGray)
    {
        if (!_isGray)
            _oldTextColor = this.color;

        this.color = isGray?GrayCol: _oldTextColor;
        _isGray = isGray;
    }
}
