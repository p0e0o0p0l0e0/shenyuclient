using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTTTTTY : MonoBehaviour
{
    public static TTTTTTY Instance = null;
    private List<string> mLogList = new List<string>();
    // Use this for initialization
    void Start ()
    {
        Instance = this;
        mLogList.Clear();
    }


    public void LogScreen(string sLog)
    {
        mLogList.Add(sLog);
        if (mLogList.Count > 10)
        {
            mLogList.RemoveAt(0);
        }
    }

    void OnGUI()
    {
        for (int i = 0; i < mLogList.Count; ++i)
        {
            GUILayout.TextField(mLogList[i]);

        }
    }
}
