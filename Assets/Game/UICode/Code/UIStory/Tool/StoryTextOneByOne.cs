using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class StoryTextOneByOne
{
    private const string REGEXCOLOR = "<color=#([0-9,a-f,A-F]{6})>(.{1,}?)</color>";
    private const char FLAG = '$';

    public class StoryTextDataOneByOne
    {
        public Text TxtLabel;
        public string[] CharArrayContext;
        public float FloatInterval;
        public int Flag;
        public string Context;

        public void Clear()
        {
            TxtLabel = null;
            CharArrayContext = null;
            Context = null;
        }
    }
    /// 文字显示队列
    private Queue<StoryTextDataOneByOne> _oneByOneQueue = new Queue<StoryTextDataOneByOne>();

    private ViTimeNode1 _node1 = new ViTimeNode1();

    public Action EndCallBack = null;

    private bool isEnd = true;

    public void Init(Text text, string context, float time, bool totalDuration = false)
    {
        StoryTextDataOneByOne obo = new StoryTextDataOneByOne();
        obo.Context = context;
        obo.CharArrayContext = GetContextArray(context);
        obo.FloatInterval = totalDuration ? 0.1f : time;
        obo.TxtLabel = text;
        _oneByOneQueue.Enqueue(obo);
    }

    private string[] GetContextArray(string context)
    {
        Regex regex = new Regex(@REGEXCOLOR);

        List<string> list = new List<string>();
        foreach (Match match in regex.Matches(context))
        {
            if (match.Groups.Count == 3)
            {
                list.AddRange(GetMatchText(match.Groups[2].Value,match.Groups[1].Value));
                string flags = string.Empty;
                for (int i = 0; i < list.Count; i++)
                    flags += FLAG;
                context = context.Replace(match.Value, flags);
            }
        }
        char[] array = context.ToCharArray();
        List<string> endList = new List<string>();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Equals(FLAG))
            {
                if (list.Count > 0)
                {
                    endList.Add(list[0]);
                    list.RemoveAt(0);
                }
            }
            else
                endList.Add(array[i].ToString());
        }
        return endList.ToArray();
    }
    private List<string> GetMatchText(string text, string color)
    {
        List<string> list = new List<string>();
        char[] array = text.ToCharArray();
        for (int i = 0; i < array.Length; i++)
        {
            list.Add(string.Format("<color=#{0}>{1}</color>", color, array[i]));
        }
        return list;
    }

    /// <summary>
    /// 播放文字
    /// </summary>
    public void Play(Action endCallBack = null)
    {
        EndCallBack = endCallBack;

        if (_oneByOneQueue.Count > 0)
        {
            isEnd = false;
            StoryTextDataOneByOne obo = _oneByOneQueue.Peek();
            obo.TxtLabel.SetTextContent(string.Empty);
            PlayWordOneByOne(obo);
        }
        else
            End();
    }
    private void End()
    {
        _node1.Detach();
        _oneByOneQueue.Clear();

        if (EndCallBack.IsNotNull())
        {
            EndCallBack();
            EndCallBack = null;
        }
    }

    public void ForceEnd()
    {
        _node1.Detach();
        _oneByOneQueue.Clear();
        EndCallBack = null;
    }

    private void NextOne(StoryTextDataOneByOne obo)
    {
        if (obo.CharArrayContext.Length > obo.Flag)
        {
            StoryManager.GetInstance.SetTime(_node1, obo.FloatInterval, (nodeInterface) => { PlayWordOneByOne(obo); });
        }
        else
        {
            obo.Clear();
            _oneByOneQueue.Dequeue();
            Play(EndCallBack);
        }
    }

    private void PlayWordOneByOne(StoryTextDataOneByOne obo)
    {
        obo.TxtLabel.SetTextContent(obo.TxtLabel.text + obo.CharArrayContext[obo.Flag++]);
        NextOne(obo);
    }

    public bool ShowAll()
    {
        if (_oneByOneQueue.Count > 0)
        {
            StoryTextDataOneByOne obo = _oneByOneQueue.Peek();
            obo.TxtLabel.SetTextContent(obo.Context);
            obo.Clear();
            End();
            return true;
        }
        return false;
    }
}

