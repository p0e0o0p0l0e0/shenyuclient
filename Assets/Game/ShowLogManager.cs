using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Net;
using System.Text;

public struct LogStruct
{
    public string message;
    public LogType type;
}

public class ShowLogManager : MonoBehaviour {

    private ShowLogManager _instance;
    public ShowLogManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private List<LogStruct> logs = new List<LogStruct>();
    private List<string> writeLogs = new List<string>();
    private List<string> sendLogs = new List<string>();
    private readonly int maxLogs = 1000;
    private readonly int maxWriteCount = 200;

    private string URL = "";
    private readonly string editorURL = "Log";

    private Dictionary<LogType, Color> logTypeColors = new Dictionary<LogType, Color>()
    {
        { LogType.Log,Color.white},
        { LogType.Warning,Color.yellow},
        { LogType.Error,Color.red},
        { LogType.Exception,Color.red},
        { LogType.Assert,Color.green},
    };

    private readonly string windowTitle = "LogWindow";
    private const int margin = 20;
    Rect windowRect = new Rect(margin, margin, Screen.width - (margin * 2), Screen.height - (margin * 4));
    static readonly GUIContent clearLabel = new GUIContent("Clear", "Clear the contents of the console.");
    static readonly GUIContent sendLabel = new GUIContent("Send", "Send the contents of the console.");
    static readonly GUIContent closeLabel = new GUIContent("Close", "Close the console.");
    Rect titleBarRect = new Rect(0, 0, 10000, 0);
    Vector2 scrollPosition;
    private int theWindowId = 123;

    private bool visible = false;

    private string outPath;
    private string outPath1;
    private string outPath2;
    private string writePath;

    private bool hasOutPath = false;
    private bool hasOutPath1 = false;
    private bool hasOutPath2 = false;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        URL = "";
        outPath = Application.persistentDataPath + "/outLog.txt";
        outPath1 = Application.persistentDataPath + "/outLog1.txt";
        outPath2 = Application.persistentDataPath + "/outLog2.txt";        

        CheckOutPath();

        Application.logMessageReceived += LogHandler;
        FingerManager.OnCustomGesture += OnCustomGesture;
    }

    private void OnCustomGesture(PointCloudGesture gesture)
    {
        OpenLogWindow();       
    }

    private void CheckLocalTxt()
    {
        if (File.Exists(outPath))
        {
            hasOutPath = true;
        }
        else
        {
            hasOutPath = false;
        }

        if (File.Exists(outPath1))
        {
            hasOutPath1 = true;
        }
        else
        {
            hasOutPath1 = false;
        }

        if (File.Exists(outPath2))
        {
            hasOutPath2 = true;
        }
        else
        {
            hasOutPath2 = false;
        }
    }

    private void CheckOutPath()
    {
        CheckLocalTxt();

#region create Txt
        if (!hasOutPath && !hasOutPath1 && !hasOutPath2)
        {
            writePath = outPath;
            FileStream fs = File.Create(outPath);
            fs.Close();
        }
        else if (hasOutPath && !hasOutPath1 && !hasOutPath2)
        {
            writePath = outPath1;
            try
            {
                FileStream fs = File.Create(writePath);
                fs.Close();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }
        else if (hasOutPath && hasOutPath1 && !hasOutPath2)
        {
            try
            {
                File.Delete(outPath);
                writePath = outPath2;
                FileStream fs = File.Create(writePath);
                fs.Close();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }
        else if (!hasOutPath && hasOutPath1 && hasOutPath2)
        {
            try
            {
                writePath = outPath;
                File.Delete(outPath1);                
                FileStream fs = File.Create(outPath);
                fs.Close();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }
        else if (hasOutPath && !hasOutPath1 && hasOutPath2)
        {
            try
            {
                File.Delete(outPath2);
                writePath = outPath1;
                FileStream fs = File.Create(writePath);
                fs.Close();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }
#endregion

    }

    public void End()
    {
        logs.Clear();
        writeLogs.Clear();
        sendLogs.Clear();

        if (visible)
        {
            CloseWindow();
        }

        //Application.logMessageReceived -= LogHandler;
        //FingerManager.OnSwipe -= OnSwipe;
    }

    void OnGUI()
    {
        if (!visible)
        {
            return;
        }

        GUILayout.Window(theWindowId, windowRect, DrawConsoleWindow, windowTitle);        
    }

    private void DrawConsoleWindow(int windowId)
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        for (int i = 0; i < logs.Count; i++)
        {
            GUI.contentColor = logTypeColors[logs[i].type];
            GUILayout.Label(logs[i].message);            
        }
        GUILayout.EndScrollView();
        GUI.contentColor = Color.white;

        //
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(clearLabel))
        {
            ClearLogs();
        }
        if (GUILayout.Button(sendLabel))
        {
            SendLogs();
        }
        if (GUILayout.Button(closeLabel))
        {
            CloseWindow();
        }
        GUILayout.EndHorizontal();
        //

        GUI.DragWindow(titleBarRect);
    }

    private void AddMessage(string msg ,LogType logType)
    {
        if (logs.Count >= maxLogs)
        {
            logs.RemoveAt(0);
        }

        logs.Add(new LogStruct
        {
            message = msg,
            type = logType,
        });        
    }

    private void AddWriteMessage(string msg, LogType logType)
    {
        if (writeLogs.Count >= maxWriteCount)
        {
            writeLogs.RemoveAt(0);            
        }
        writeLogs.Add(string.Format("{0}\n{1}&", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), msg));              
    }

    private void ClearLogs()
    {
        logs.Clear();
    }

    private void SendLogs()
    {
        WriteToLocalTxt();
        CheckLocalTxt();
        if (hasOutPath)
        {
            SendLocalLogTxt(outPath);
        }
        if (hasOutPath1)
        {
            SendLocalLogTxt(outPath1);
        }
        if (hasOutPath2)
        {
            SendLocalLogTxt(outPath2);
        }
    }

    private void OpenLogWindow()
    {
        visible = true;
    }

    private void CloseWindow()
    {
        visible = false;
    }

    private void LogHandler(string condition, string stackTrace, LogType type)
    {
        AddMessage(string.Format("{0}\n{1}",condition,stackTrace), type);
        //if (type != LogType.Log)
        {
            AddWriteMessage(string.Format("{0}\n{1}", condition, stackTrace), type);
        }        
    }

    private void WriteToLocalTxt()
    {
        if (string.IsNullOrEmpty(writePath))
        {
            return;
        }

        if (File.Exists(writePath))
        {
            File.Delete(writePath);
        }
        FileStream ffss = File.Create(writePath);
        ffss.Close();

        if (writeLogs.Count > 0)
        {
            StreamWriter sw;
            sw = File.AppendText(writePath);
            for (int i = 0; i < writeLogs.Count; i++)
            {                       
                sw.WriteLine(writeLogs[i]);                
            }
            sw.Close();
            sw.Dispose();
        }
    }

    private void SendLocalLogTxt(string path)
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            StreamReader streamReader = File.OpenText(path);
            string str = streamReader.ReadToEnd();
            streamReader.Close();

            if (!Directory.Exists(editorURL))
            {
                Directory.CreateDirectory(editorURL);
            }

            string tempPath = editorURL + path.Replace(Application.persistentDataPath, "");
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
            FileStream ffss = File.Create(tempPath);
            ffss.Close();

            StreamWriter streamWriter = File.AppendText(tempPath);
            streamWriter.Write(str);
            streamWriter.Close();

            AddMessage(string.Format("Log文件保存在了Assets同级目录: {0}", tempPath), LogType.Assert);            
        }
        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            /*
            // 设置参数
            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
            int pos = path.LastIndexOf("\\");
            string fileName = path.Substring(pos + 1);
            //请求头部信息 
            StringBuilder sbHeader = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"file\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] bArr = new byte[fs.Length];
            fs.Read(bArr, 0, bArr.Length);
            fs.Close();
            Stream postStream = request.GetRequestStream();
            postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
            postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            postStream.Write(bArr, 0, bArr.Length);
            postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            postStream.Close();
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            */
        }
    }
}
