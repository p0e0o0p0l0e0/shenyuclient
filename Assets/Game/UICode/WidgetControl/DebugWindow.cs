using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DebugWindow : MonoBehaviour
{

    private Transform _top = null;
    //private List<SpaceStruct> _spaceList = new List<SpaceStruct>();
    private InputField _inputField = null;
    private Button _sendBtn = null;
    public static DebugWindow Instance { get; set; }
    // Use this for initialization
    void Start () {
        Instance = this;
        _top = this.transform.Find("Top");
        _top.gameObject.SetActive(false);
        _inputField = this.GetComponentInChildren<InputField>(true);
        _sendBtn = this.GetComponentInChildren<Button>(true);
        _sendBtn.onClick.AddListener(_OnClickSend);
        ProjectAScript.StartCommand();
    }
    private void _OnClickSend()
    {
        string cmd = _inputField.text;
        GMExecer.Exec(cmd);
        _inputField.text = "";
    }
    //private void _onClickSpace(int id, object obj)
    //{
    //    SpaceStruct sstruct = _spaceList[id];
    //    //PlayerServerInvoker.GotoBigSpace(Player.Instance, (UInt32)sstruct.ID);
    //    UIManagerUtility.GotoSpace((UInt32)sstruct.ID);
    //}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bool isVisible = _top.gameObject.active;
            _top.gameObject.SetActive(!isVisible);
        }
    }
}
