using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class I18NManager : IDisposable
{
    private static I18NManager _handler = null;
    public static I18NManager Instance
    {
        get
        {
            if (_handler == null)
                _handler = new I18NManager();
            return _handler;
        }
    }
    private Dictionary<string, string> _words = new Dictionary<string, string>();
    public void Append(string key, string val)
    {
        if (string.IsNullOrEmpty(key))
        {
            ViDebuger.Warning("I18NManager.append key is null");
            return;
        }
        if (!_words.ContainsKey(key))
        {
            _words[key] = val;
        }
        else
        {
            ViDebuger.Warning("I18NManager.append "+key+" is already exist");
        }
    }
    public string GetWord(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return "";
        }
        if (_words.ContainsKey(key))
            return _words[key];
        return "";
    }
    public void Dispose()
    {
        _handler = null;
    }
}
