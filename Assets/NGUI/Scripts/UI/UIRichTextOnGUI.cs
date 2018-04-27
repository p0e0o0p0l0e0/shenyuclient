#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY || UNITY_WINRT)
#define MOBILE
#endif

using UnityEngine;

/// <summary>
/// This class is added by UIRichText when it gets selected in order to be able to receive input events properly.
/// The reason it's not a part of UIInput is because it allocates 336 bytes of GC every update because of OnGUI.
/// It's best to only keep it active when it's actually needed.
/// </summary>

[RequireComponent(typeof(UIRichText))]
public class UIRichTextOnGUI : MonoBehaviour
{
#if !MOBILE
	[System.NonSerialized] UIRichText mText;

	void Awake() { mText = GetComponent<UIRichText>(); }

	/// <summary>
	/// Unfortunately Unity 4.3 and earlier doesn't offer a way to properly process events outside of OnGUI.
	/// </summary>

	void OnGUI ()
	{
		if (Event.current.rawType == EventType.KeyDown)
			mText.ProcessEvent(Event.current);
	}
#endif
}
