using EditorCommon;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ResourceFormat
{
    public class FormatDataControl<T> where T : ImportData, new()
    {
        public int Index
        {
            get { return m_index; }
        }
        public T Data
        {
            get { return m_index == -1 ? null : m_dataList[m_index]; }
        }
        public T SelectData
        {
            get { return m_index == -1 ? null : m_dataList[m_index]; }
        }
        public List<T> DataList
        {
            get { return m_dataList; }
        }

        public virtual void OnDataSelected(object selected, int col)
        {
            ImportData importData = selected as ImportData;
            if (importData == null)
                return;

            //m_editorData.CopyData(importData);
            m_index = importData.Index;
            if (importData != null && m_showTable != null)
            {
                m_showTable.RefreshData(importData.GetObjects());
            }
        }
        public virtual void OnInfoSelected(object selected, int col)
        {
            BaseInfo texInfo = selected as BaseInfo;
            if (texInfo == null)
                return;
            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath(texInfo.Path, typeof(UnityEngine.Object));
            EditorGUIUtility.PingObject(obj);
            Selection.activeObject = obj;
        }
        public virtual void AddData()
        {
            for (int i = 0; i < m_dataList.Count; ++i)
            {
                if (m_dataList[i].RootPath == mRootPath)
                {
                    Debug.Log("目录已经存在!");
                    return;
                }
            }
            m_index = m_dataList.Count;
            T data = new T();
            data.RootPath = mRootPath;
            m_dataList.Add(data);
            RefreshDataTable();
            ConfigData.SaveData();
        }
        public virtual void SaveData()
        {
            if (m_index == -1)
                return;
            T data = m_dataList[m_index];
            data.ClearObject();

            OnDataSelected(data, m_index);
            ConfigData.SaveData();
            RefreshDataWithSelect();
        }
        public virtual void DeleteCurrentData()
        {
            if (m_index == -1)
                return;
            m_dataList.RemoveAt(m_index);
            m_index = -1;
            RefreshDataTable();
            ConfigData.SaveData();
        }
        public virtual void ModifDataPriority(bool up)
        {
            if (m_index == -1)
                return;
            var temp = m_dataList[m_index];
            if (up)
            {
                if (m_index == 0)
                    return;
                m_dataList[m_index] = m_dataList[m_index - 1];
                m_dataList[m_index - 1] = temp;
            }
            else
            {
                if (m_index + 1 == m_dataList.Count)
                    return;
                m_dataList[m_index] = m_dataList[m_index + 1];
                m_dataList[m_index + 1] = temp;
            }
            ConfigData.SaveData();

            RefreshDataWithSelect();
            if (m_dataTable != null)
            {
                m_dataTable.SetSelected(temp);
            }
        }

        public virtual void RefreshBaseData()
        {
            List<string> list = EditorPath.GetAssetPathList(FormatConfig.ResourceRootPath);
            _RefreshList(list);
        }

        public virtual void RefreshDataByRootPath()
        {
            List<string> list = EditorPath.GetAssetPathList(FormatConfig.ResourceRootPath + "/" + SelectData.RootPath);
            _RefreshList(list);
        }

        protected virtual void _RefreshList(List<string> list)
        {
        }

        public virtual void OnDataSelectedIndex()
        {
            if (m_index == -1)
                return;
            OnDataSelected(m_dataList[m_index], m_index);
        }

        public virtual void RefreshDataWithSelect()
        {
            if (m_dataTable != null)
            {
                m_dataTable.RefreshData(EditorTool.ToObjectList<T>(m_dataList));
            }
        }

        public void RefreshDataTable()
        {
            for (int i = 0; i < m_dataList.Count; ++i)
            {
                m_dataList[i].Index = i;
            }

            if (m_dataTable != null)
            {
                m_dataTable.RefreshData(EditorTool.ToObjectList<T>(m_dataList));
            }
        }

        public void ClearSelectData()
        {
            SelectData.ClearObject();
        }

        public void ClearAllData()
        {
            for (int i = 0; i < m_dataList.Count; ++i)
            {
                m_dataList[i].ClearObject();
                m_dataList[i].Index = i;
            }

            if (m_dataTable != null)
            {
                m_dataTable.RefreshData(EditorTool.ToObjectList<T>(m_dataList));
            }
        }

        public virtual void Draw()
        {
           // T data = m_editorData;

            GUILayout.BeginHorizontal(TableStyles.Toolbar);
            {
                GUILayout.Label("RootPath: ", GUILayout.Width(80));
                mRootPath = EditorGUILayout.TextField(mRootPath, TableStyles.TextField, GUILayout.Width(360));
                if (GUILayout.Button("Add Data", TableStyles.ToolbarButton, GUILayout.MaxWidth(140)))
                {
                    if (string.IsNullOrEmpty(mRootPath))
                    {
                        Debug.Log("RootPath: Empty");
                        return;
                    }
                    AddData();
                }

                if (GUILayout.Button("Save Data", TableStyles.ToolbarButton, GUILayout.MaxWidth(140)))
                {
                    SaveData();
                }

                if (GUILayout.Button("Delete Current Data", TableStyles.ToolbarButton, GUILayout.MaxWidth(140)))
                {
                    DeleteCurrentData();
                }
                GUILayout.FlexibleSpace();
            }
            GUILayout.EndHorizontal();
        }

        string mRootPath = string.Empty;

        protected TableView m_dataTable;
        protected TableView m_showTable;

        protected int m_index = -1;
        protected List<T> m_dataList = null;
    }
}
