using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/********************************************************************
	created:	2016/09/24
	created:	24:9:2016   11:20
	filename: 	D:\Resource\client\trunk\Project\Assets\Editor\Scripts\Story\StoryFDataINspector.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Editor\Scripts\Story
	file base:	StoryFDataINspector
	file ext:	cs
	author:		zlj
	
	purpose:	剧情功能实现模块面板显示
*********************************************************************/

[CustomEditor(typeof(StoryFunctionData))]
public class StoryFDataInspector : StoryDataInspector
{
    private StoryFunctionStoryboardData.MOVIE_TYPE movieType;
    private StoryFunctionStoryboardData.CameraControlType cameraType;
    private SerializedProperty movieData;
    private StoryFunction storyFunction;

    void OnEnable()
    {
        movieData = serializedObject.FindProperty("data");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        StoryFunctionData data = (StoryFunctionData)target;
        GUI.enabled = true;
        
        GUI.color = Color.cyan;
        data.type = (StoryFunctionData.FUCTION_TYPE)EditorGUILayout.Popup("功能类型:", (int)data.type, data.typeMenu);
        GUI.color = Color.white;

        EditorGUILayout.Space();
        switch (data.type)
        {
            case StoryFunctionData.FUCTION_TYPE.TEXTURE:
                EditTextureTextFun(data.textData);
                EditorGUILayout.Space();
                EditorGUILayout.BeginVertical("box");
                GUI.color = Color.green;
                data.nextType = (StoryFunctionData.NEXT_TYPE)EditorGUILayout.Popup("下一步的方式:", (int)data.nextType, data.nextTypeNames);
                switch (data.nextType)
                {
                    case StoryFunctionData.NEXT_TYPE.TIME:
                        data.nextTime = (EditorGUILayout.FloatField("下一步延迟时间:", data.nextTime));
                        break;
                }
                GUI.color = Color.white;
                EditorGUILayout.EndVertical();
                break;
            case StoryFunctionData.FUCTION_TYPE.BUBBLING:
                FloatField("冒泡功能起始等待时间:", ref data.startWaitTime);
                EditBubblingFun(data.bubblingData);
                break;
            case StoryFunctionData.FUCTION_TYPE.MOVIE:
                FloatField("起始等待时间:", ref data.startWaitTime);
                EditMovieFun(data.movieData);
                break;
            case StoryFunctionData.FUCTION_TYPE.DISPLACEMENT:
                FloatField("起始等待时间:", ref data.startWaitTime);
                EditDisplacementFun(data.displacementData);
                break;
            case StoryFunctionData.FUCTION_TYPE.GAMESPEED:
                FloatField("起始等待时间:", ref data.startWaitTime);
                EditGameSpeedFun(data.gameSpeedData);
                break;
            case StoryFunctionData.FUCTION_TYPE.BACKMUSIC:
                FloatField("起始等待时间:", ref data.startWaitTime);
                EditBackMusicFun(data.backMusicData);
                break;
            case StoryFunctionData.FUCTION_TYPE.CAMERA:
                FloatField("起始等待时间:", ref data.startWaitTime);
                EditCameraFun(data.cameraData);
                break;
            case StoryFunctionData.FUCTION_TYPE.ANIMATION:
                FloatField("起始等待时间:", ref data.startWaitTime);
                EditAnimationFun(data.animationData);
                break;
            case StoryFunctionData.FUCTION_TYPE.BLINKOFANEYE:
                FloatField("起始等待时间:", ref data.startWaitTime);
                EditBlinkOfAnEyeFun(data.blinkOfAnEyeData);
                break;
            case StoryFunctionData.FUCTION_TYPE.CINEMADIRECTOR:
                FloatField("起始等待时间:", ref data.startWaitTime);
                EditCinemaDirectorFun(data.cinemaDirectorData);
                break;
            case StoryFunctionData.FUCTION_TYPE.BLACKBACKGROUND:
                FloatField("起始等待时间:", ref data.startWaitTime);
                EditBlackBackgroundFun(data.blackBackgroundData);
                break;
            default:
                break;
        }
        EditorGUILayout.BeginVertical("box");
        GUI.color = Color.green;
        storyFunction = data.reqStoryFunction;
        data.reqStoryFunction = EditorGUILayout.ObjectField("后续步骤:", data.reqStoryFunction, typeof(StoryFunction), true) as StoryFunction;
        if (storyFunction != null)
            storyFunction.isAutoPlay = storyFunction != data.reqStoryFunction;
        GUI.color = Color.white;
        EditorGUILayout.EndVertical();
        serializedObject.ApplyModifiedProperties();
    }
    /// <summary>
    /// 编辑插图剧情功能
    /// </summary>
    private void EditTextureTextFun(StoryFunctionTextureTextData data)
    {
        EditorGUILayout.BeginVertical("box");
        GUI.color = Color.yellow;
        data.headActor = (StoryFunctionTextureTextData.HEAD_ACTOR)EditorGUILayout.EnumPopup("头像位置:", data.headActor);
        GUI.color = Color.white;
        EditAppearanceModeMenu(data.appearanceData);
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();
        EditDialogUIMenu(data.dialogData);

        EditorGUILayout.BeginVertical("box");
        data.dialogStylePath = StoryEditorUtils.ShowSelectResMenu(ResType.Texture, data.dialogStylePath, "请选择对话框样式图片(不选为默认图片)", "请选择对话框样式图片", "对话框样式图片路径:");
        EditTextureStyleMenu(data.backgroundTexData, "请选择背景图片(不选则不显示)", "请选择背景图片", "背景图片路径:");

        if (!string.IsNullOrEmpty(data.backgroundTexData.texPath))
        {
            EditorGUILayout.Space();
            ShowTextStyleMenu(data.titleContent, "输入标题内容:", "请选择文字显示方式:", "请选择文字显示位置:");
            EditorGUILayout.Space();
            ShowTextStyleMenu(data.subtitleContent, "输入字幕内容:", "请选择文字显示方式:", "请选择文字显示位置:");
        }
        EditorGUILayout.EndVertical();
    }
    /// <summary>
    // 编辑冒泡动态语音功能
    /// </summary>
    private void EditBubblingFun(StoryFunctionBubblingData data)
    {
        EditorGUILayout.Space();
        data.bubblingTexPath = StoryEditorUtils.ShowSelectResMenu(ResType.Texture, data.bubblingTexPath, "请选择冒泡图片(不选为默认图片)", "请选择冒泡图片", "冒泡图片路径:");
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        Label("要说话者的人物类型：", Color.green);
        GUI.color = Color.yellow;
        data.roleData.controlType = (StoryRoleData.ROLETYPE)GUILayout.Toolbar((int)data.roleData.controlType, data.roleData.roleTypeNames);
        GUI.color = Color.white;
        EditorGUILayout.Space();
        FloatField("对话播放等待时间:", ref data.dialogWaitTime);
        switch (data.roleData.controlType)
        {
            //为主角时
            case StoryRoleData.ROLETYPE.LEAD:
                BoolField("是否为本地角色", ref data.roleData.isLocal);
                if (data.roleData.isLocal)
                    BoolField("冒泡结束是否隐藏此人", ref data.isHideCharacter);
                else
                    data.isHideCharacter = false;
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical("box");
                Label("男主角:", Color.green);
                EditDialogMenu(data.soundData);
                Label("女主角:", Color.green);
                EditDialogMenu(data.soundData1);
                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
                break;
            //为英雄时
            case StoryRoleData.ROLETYPE.HERO:
                return;
                //EditorGUILayout.Space();
                //EditHeroMenu(data);
                //EditNormalRoleActionMenu(ref data.actionWaitTime, data.roleActionData);
                //data.isHideCharacter = false;
                break;
            //为怪物时
            case StoryRoleData.ROLETYPE.ENEMY:
                EditEnemyMenu(data.roleData);
                BoolField("冒泡结束是否隐藏此人", ref data.isHideCharacter);
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical("box");
                Label("碰到男主角:", Color.green);
                EditDialogMenu(data.soundData);
                Label("碰到女主角:", Color.green);
                EditDialogMenu(data.soundData1);
                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
                break;
            //为援军时
            case StoryRoleData.ROLETYPE.SceneNPC:
                EditSceneNPCMenu(data.roleData);
                BoolField("冒泡结束是否隐藏此人", ref data.isHideCharacter);
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical("box");
                Label("碰到男主角:", Color.green);
                EditDialogMenu(data.soundData);
                Label("碰到女主角:", Color.green);
                EditDialogMenu(data.soundData1);
                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
                break;
        }
        EditorGUILayout.Space();
    }
    private void EditMovieFun(StoryFunctionMovieData data)
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        data.moviePath = StoryEditorUtils.ShowSelectResMenu(ResType.Movie, data.moviePath, "请选择视频(不选默认不播)", "请选择视频", "视频路径:");
        BoolField("是否能够跳过:", ref data.isCanJump);
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
    }
    /// <summary>
    /// 编辑分镜功能
    /// </summary>
    private void EditStoryboardFun(StoryFunctionStoryboardData data, GameObject go)
    {
        GUI.color = Color.yellow;
        movieType = data.movieType;
        data.movieType = (StoryFunctionStoryboardData.MOVIE_TYPE)EditorGUILayout.Popup("分镜的功能:", (int)data.movieType, data.movieTypeNames);
        GUI.color = Color.white;
        EditorGUILayout.Space();

        if (movieType != data.movieType)
        {
            if (data.movieType != StoryFunctionStoryboardData.MOVIE_TYPE.Camera)
            {
                StoryEditorUtils.SetScriptState<Camera>(go, false);
            }
            else
            {
                StoryEditorUtils.SetScriptState<Camera>(go, data.cameraControlType != StoryFunctionStoryboardData.CameraControlType.CameraPath);
            }
        }
        switch (data.movieType)
        {
            case StoryFunctionStoryboardData.MOVIE_TYPE.EdgeFrame:
                EditTextureStyleMenu(data.edgeFramTexData, "请选择边缘图片(不选为默认图片)", "请选择边缘图片", "边缘图片路径:");
                break;
            case StoryFunctionStoryboardData.MOVIE_TYPE.Dialog:
                EditRoleMenu(data.roleData);
                data.bubblingTexPath = StoryEditorUtils.ShowSelectResMenu(ResType.Texture, data.bubblingTexPath, "请选择冒泡图片(可以不选)", "请选择冒泡图片", "冒泡图片路径:");
                if (!string.IsNullOrEmpty(data.bubblingTexPath))
                    data.bubblingExistTime = EditorGUILayout.FloatField("冒泡图片存留时长:", data.bubblingExistTime);
                EditDialogMenu(data.soundData);
                break;
            case StoryFunctionStoryboardData.MOVIE_TYPE.Camera:
                cameraType = data.cameraControlType;
                data.cameraControlType = (StoryFunctionStoryboardData.CameraControlType)EditorGUILayout.EnumPopup("相机操作类型:", data.cameraControlType);

                if (cameraType != data.cameraControlType)
                {
                    StoryEditorUtils.SetScriptState<Camera>(go, data.cameraControlType != StoryFunctionStoryboardData.CameraControlType.CameraPath);
                    if (data.cameraControlType == StoryFunctionStoryboardData.CameraControlType.CameraPath)
                    {
                        go.transform.localPosition = Vector3.zero;
                        go.transform.localEulerAngles = Vector3.zero;
                        go.transform.localScale = Vector3.one;
                    }
                }
                switch (data.cameraControlType)
                {
                    case StoryFunctionStoryboardData.CameraControlType.ChangeCamera:
                        StoryEditorUtils.ShowPrompt("请拖动此对象的位置,本对象的位置为移动目标的位置;\n请旋转本对象的角度,本对象的角度为摄像机旋转后的角度.");
                        break;
                    case StoryFunctionStoryboardData.CameraControlType.MoveCamera:
                        data.costTime = EditorGUILayout.FloatField("移动花费的时间:", data.costTime);
                        StoryEditorUtils.ShowPrompt("请拖动此对象的位置,本对象的位置为移动目标的位置");
                        break;
                    case StoryFunctionStoryboardData.CameraControlType.RotateCamera:
                        data.costTime = EditorGUILayout.FloatField("旋转花费的时间:", data.costTime);
                        StoryEditorUtils.ShowPrompt("请旋转本对象的角度,本对象的角度为摄像机旋转后的角度");
                        break;
                    case StoryFunctionStoryboardData.CameraControlType.CameraPath:
                        StoryEditorUtils.ShowPrompt("先学习一下插件的使用。");
                        break;
                }
                break;
            case StoryFunctionStoryboardData.MOVIE_TYPE.RolePreset:
                EditRoleMenu(data.roleData);
                StoryEditorUtils.ShowPrompt("请拖动此对象的位置,本对象的位置为移动目标的位置");
                break;
            case StoryFunctionStoryboardData.MOVIE_TYPE.RoleAction:
                data.roleActionType = (StoryFunctionStoryboardData.RoleActionType)EditorGUILayout.EnumPopup("人物行为操作类型:", data.roleActionType);
                switch (data.roleActionType)
                {
                    case StoryFunctionStoryboardData.RoleActionType.PlayAnimation:
                        EditRoleMenu(data.roleData);
                        data.animatonName = EditorGUILayout.TextField("人物播放动作的文件名:", data.animatonName);
                        data.actionSpeed = EditorGUILayout.FloatField("人物行为频率:", data.actionSpeed);
                        data.isLoop = EditorGUILayout.Toggle("是否循环:", data.isLoop);
                        break;
                    case StoryFunctionStoryboardData.RoleActionType.Move:
                        EditRoleMenu(data.roleData);
                        data.moveSpeed = EditorGUILayout.FloatField("角色移动的速度:", data.moveSpeed);
                        StoryEditorUtils.ShowPrompt("请拖动此对象的位置,本对象的位置为移动目标的位置");
                        break;
                }
                break;
        }
    }
    /// <summary>
    /// 编辑位移功能
    /// </summary>
    private void EditDisplacementFun(StoryFunctionDisplacementData data)
    {
        EditorGUILayout.Space(); 
        EditorGUILayout.BeginVertical("box");
        Label("要位移的人物类型：", Color.green);
        EditRoleMenu(data.roleData);

        EditorGUILayout.BeginVertical("box");
        FloatField("移动速度：",ref data.moveSpeed);
        Vector3Field("要达到的位置：",ref data.position);
        Vector3Field("要朝向的角度：", ref data.angle);
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
    }
    /// <summary>
    /// 编辑游戏速度功能
    /// </summary>
    private void EditGameSpeedFun(StoryFunctionGameSpeedData data)
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        FloatField("游戏速度：", ref data.gameSpeed);
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
    }
    /// <summary>
    /// 编辑背景音功能
    /// </summary>
    private void EditBackMusicFun(StoryFunctionBackMusicData data)
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        IntField("声音资源ID:", ref data.soundID);
        EditorGUILayout.BeginHorizontal();
        Label("背景音量:");
        SliderField(ref data.volume, 0, 1);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
    }
    /// <summary>
    /// 编辑相机功能
    /// </summary>
    private void EditCameraFun(StoryFunctionCameraData data)
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.BeginVertical("box");
        Label("镜头行为:", Color.green);
        BoolField("分镜中是否隐藏主角:", ref data.isHidePlayer);
        FloatField("分镜中冒泡偏移高度", ref data.highOffset);
        EditPlayCameraAnimatorMenu(data.cameraAnimatorData);
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();

        EditCameraShakesMenu(data.cameraShakeInfos);
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
    }
    /// <summary>
    /// 编辑眨眼功能
    /// </summary>
    private void EditBlinkOfAnEyeFun(StoryFunctionCameraBlinkOfAnEyeData data)
    {
        EditorGUILayout.Space();
        
        EditCameraBlinkOfAnEyeMenu(data.cameraBlinkOfAnEyeInfo);
    }
    /// <summary>
    /// 编辑黑幕功能
    /// </summary>
    private void EditBlackBackgroundFun(StoryFunctionBlackBackgroundData data)
    {
        EditorGUILayout.Space();

        EditBlackBackgroundMenu(data.blackBackgroundData);
    }
    /// <summary>
    /// 编辑剧情动画
    /// </summary>
    private void EditCinemaDirectorFun(StoryFunctionCinemaDirectorData data)
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        EditFileMenu(data.fileData, "剧情动画文件");
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
    }
    /// <summary>
    /// 编辑动作功能
    /// </summary>
    private void EditAnimationFun(StoryFunctionAimationData data)
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        GUI.color = Color.yellow;
        data.roleData.controlType = (StoryRoleData.ROLETYPE)GUILayout.Toolbar((int)data.roleData.controlType, data.roleData.roleTypeNames);
        GUI.color = Color.white;
        EditorGUILayout.Space();
        switch (data.roleData.controlType)
        {
            case StoryRoleData.ROLETYPE.LEAD:
                BoolField("是否为本地角色", ref data.roleData.isLocal);
                break;
            case StoryRoleData.ROLETYPE.HERO:
                break;
            case StoryRoleData.ROLETYPE.ENEMY:
                EditEnemyMenu(data.roleData);
                break;
            case StoryRoleData.ROLETYPE.SceneNPC:
                EditSceneNPCMenu(data.roleData);
                break;
        }
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        Label("人物行为:", Color.green);
        IntField("技能ID:", ref data.roleActionData.skillID);
        TextField("或播动作名称：", ref data.roleActionData.animName);
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
    }
    /// <summary>
    /// 编辑英雄显示界面
    /// </summary>
    /// <param name="data"></param>
    protected void EditHeroMenu(StoryFunctionBubblingData data)
    {
        data.roleData.roleId = EditorGUILayout.IntField("通用英雄ID:", data.roleData.roleId);
        EditDialogMenu(data.soundData);

        Label("=====================================", Color.green);

        if (data.heroList.Count != 0)
        {
            GUI.color = Color.green;
            data.showDetail = EditorGUILayout.Foldout(data.showDetail, "独立英雄列表");
            GUI.color = Color.white;
        }
        if (data.showDetail)
        {
            for (int i = 0; i < data.heroList.Count; i++)
            {
                GUI.color = Color.cyan;
                data.heroList[i] = EditorGUILayout.IntField("独立英雄ID" + (i + 1) + ":", data.heroList[i]);
                GUI.color = Color.white;
                EditDialogMenu(data.soundDataList[i]);
            }
        }
        GUI.color = Color.cyan;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("添加独立英雄"))
        {
            data.heroList.Add(0);
            data.soundDataList.Add(new StorySoundData());
        }
        if (GUILayout.Button("删除独立英雄"))
        {
            if (data.heroList.Count > 0)
                data.heroList.RemoveAt(data.heroList.Count - 1);
            if (data.soundDataList.Count > 0)
                data.soundDataList.RemoveAt(data.soundDataList.Count - 1);
        }
        GUILayout.EndHorizontal();
        Label("=====================================",Color.green);
    }
    /// <summary>
    /// 对话内容和语音
    /// </summary>
    /// <param name="soundData"></param>
    private void EditDialogMenu(StorySoundData soundData)
    {
        EditorGUILayout.BeginVertical("box");
        if (soundData.storyTextArray.Count != 0)
            soundData.showDetail = EditorGUILayout.Foldout(soundData.showDetail, "对话内容数组");
        if (soundData.showDetail)
        {
            for (int i = 0; i < soundData.storyTextArray.Count; i++)
            {
                soundData.storyTextArray[i] = (EditorGUILayout.TextField("对话的内容中文" + (i + 1) + ":", soundData.storyTextArray[i]));
                soundData.waitTime[i] = (EditorGUILayout.FloatField("文字停留时长:", soundData.waitTime[i]));
            }
        }
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("添加对话内容"))
        {
            soundData.storyTextArray.Add("");
            soundData.waitTime.Add(1);
        }
        if (GUILayout.Button("删除对话内容"))
        {
            if (soundData.storyTextArray.Count > 0)
            {
                soundData.storyTextArray.RemoveAt(soundData.storyTextArray.Count - 1);
                soundData.waitTime.RemoveAt(soundData.waitTime.Count - 1);
            }
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditSingleSoundMenu(soundData);
    }
    /// <summary>
    /// 设置文字类型显示
    /// </summary>
    /// <returns></returns>
    public void ShowTextStyleMenu(StoryTextData data, string title1, string title2, string title3)
    {
        data.showContext = EditorGUILayout.TextField(title1, data.showContext);
        data.showTextType = (StoryTextData.ShowTextType)StoryEditorUtils.ShowEnumDataMenu(title2, data.showTextTypeNames, (int)data.showTextType);

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(title3);
        data.textPositionType = (StoryTextData.TextPositionType)EditorGUILayout.EnumPopup(data.textPositionType);
        GUILayout.EndHorizontal();

        if (data.showTextType == StoryTextData.ShowTextType.OneByOne)
            data.interval = EditorGUILayout.FloatField("字之间时间间隔：", data.interval);
        EditorGUILayout.Space();
    }
    /// <summary>
    /// 编辑声音界面
    /// </summary>
    /// <param name="soundData"></param>
    private void EditSingleSoundMenu(StorySoundData soundData)
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        FloatField("声音播放等待时间:", ref soundData.soundWaitTime);
        IntField("声音资源ID:", ref soundData.soundID);//soundData.soundID = StoryEditorUtils.ShowSelectResMenu(ResType.Audio, soundData.soundID, "请选择语音文件(不选不播放语音)", "请选择语音文件", "语音文件路径:");
        FloatField("声音播放时长:", ref soundData.soundDuration);
        EditorGUILayout.EndVertical();
    }
    /// <summary>
    /// 编辑图片显示方式
    /// </summary>
    /// <param name="texData"></param>
    /// <param name="title1"></param>
    /// <param name="title2"></param>
    /// <param name="title3"></param>
    private void EditTextureStyleMenu(StoryTextureData texData, string title1, string title2, string title3)
    {
        texData.texPath = StoryEditorUtils.ShowSelectResMenu(ResType.Texture, texData.texPath, title1, title2, title3);

        if (!string.IsNullOrEmpty(texData.texPath))
        {
            EditorGUILayout.Space();
            texData.showTextureType = (StoryTextureData.TextureStyleType)EditorGUILayout.Popup("图片出现方式:", (int)texData.showTextureType, texData.textTypeNames);
            if (texData.showTextureType == StoryTextureData.TextureStyleType.Slow)
                texData.showDuration = EditorGUILayout.FloatField("图片完全显示需要时间：", texData.showDuration);
            EditorGUILayout.Space();
            texData.hideTextureType = (StoryTextureData.TextureStyleType)EditorGUILayout.Popup("图片隐藏方式:", (int)texData.hideTextureType, texData.textTypeNames);
            if (texData.hideTextureType == StoryTextureData.TextureStyleType.Slow)
                texData.hideDuration = EditorGUILayout.FloatField("图片完全隐藏需要时间：", texData.hideDuration);
            EditorGUILayout.Space();
            StoryEditorUtils.ShowPrompt("建议渐隐渐现时间最小0.5秒,最长3秒");
        }
    }
    /// <summary>
    /// 编辑文件类型界面
    /// </summary>
    /// <param name="fileData"></param>
    private void EditFileMenu(StoryFileData fileData,string fileName)
    {
        EditorGUILayout.BeginHorizontal();
        Label(fileName + "文件:", Color.yellow);
        fileData.prefab = EditorGUILayout.ObjectField(fileData.prefab, typeof(GameObject), false) as GameObject;
        EditorGUILayout.EndHorizontal();
        if (fileData.prefab != null)
        {
            fileData.prefabPath = AssetDatabase.GetAssetPath(fileData.prefab);
            EditorGUILayout.TextField("配置文件路径:", fileData.prefabPath);
        }
    }
    /// <summary>
    /// 编辑人物行为界面
    /// </summary>
    /// <param name="fileData"></param>
    private void EditNormalRoleActionMenu(ref float waitTime,StoryRoleActionData actionData)
    {
        EditorGUILayout.Space();
        Label("人物行为:", Color.green);
        FloatField("动作播放等待时间:", ref waitTime);
        IntField("技能ID:", ref actionData.skillID);
        TextField("或播动作名称：", ref actionData.animName);
        //EditFileMenu(actionData.actionFileData, "人物动作");
        EditorGUILayout.Space();
    }
    /// <summary>
    /// 编辑主角类型人物行为界面
    /// </summary>
    /// <param name="actionData"></param>
    private void EditLeaderActionMenu(StoryRoleActionData actionData)
    {
        if (actionData.leaderActionFileData.Count == 0)
        {
            for (int i = 0; i < (int)LeaderProfession.Count; i++)
            {
                actionData.leaderProfessionList.Add((LeaderProfession)i);
                actionData.leaderActionFileData.Add(new StoryFileData());
            }
        }
        for (int i = 0; i < (int)LeaderProfession.Count; i++)
            EditFileMenu(actionData.leaderActionFileData[i], actionData.leaderProfessionList[i].ToProfession() + "动作");
    }
    /// <summary>
    /// 编辑出现方式
    /// </summary>
    /// <param name="appearanceData"></param>
    private void EditAppearanceModeMenu(StoryAppearanceData appearanceData)
    {
        EditorGUILayout.BeginHorizontal();
        GUI.color = Color.yellow;
        GUILayout.Label("出现方式：");
        appearanceData.appearanceMode = (StoryAppearanceData.AppearanceMode)EditorGUILayout.Popup((int)appearanceData.appearanceMode, appearanceData.appearanceModeNames);
        GUI.color = Color.white;
        EditorGUILayout.EndHorizontal();
        switch (appearanceData.appearanceMode)
        {
            case StoryAppearanceData.AppearanceMode.Normal:
                BoolField("是否改变相机范围:", ref appearanceData.isChangeCameraView);
                if (appearanceData.isChangeCameraView)
                {
                    FloatField("相机新的视角范围:", ref appearanceData.newView);
                    FloatField(" 相机改变视角时长 :", ref appearanceData.changFOVDuration);
                }
                break;
            case StoryAppearanceData.AppearanceMode.WipeInOut:
                FloatField("移入需要的时间:", ref appearanceData.moveInDuration);
                FloatField("移出需要的时间:", ref appearanceData.moveOutDuration);
                Vector3Field("起始移动位置:", ref appearanceData.startPoint);
                Vector3Field("目的地位置:", ref appearanceData.endPoint);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 对话框显示数据
    /// </summary>
    /// <param name="dialogData"></param>
    private void EditDialogUIMenu(StoryDialogData dialogData)
    {
        EditorGUILayout.BeginVertical("box");
        GUILayout.Label("限制类型：");
        dialogData.limitRoleType = (StoryDialogData.LimitRoleType)GUILayout.Toolbar((int)dialogData.limitRoleType, dialogData.limitRoleTypeNames);
        EditorGUILayout.Space();
        switch (dialogData.limitRoleType)
        {
            case StoryDialogData.LimitRoleType.None:
                TextField("角色名称:", ref dialogData.roleName);
                EditDialogFileMenu(dialogData.dialogFileData.t, dialogData.limitRoleType);
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical("box");
                Label("对话数据:");
                EditDialogMenu(dialogData.soundData.t);
                EditorGUILayout.EndVertical();
                break;
            case StoryDialogData.LimitRoleType.Leader:
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical("box");
                BoolField("区分男女数据(默认男性)", ref dialogData.isDistinguish);
                EditorGUILayout.BeginVertical("box");
                Label("男主角对话数据:", Color.yellow);
                EditModelProfessionMenu(dialogData.dialogFileData);
                EditSoundProfessionMenu(dialogData.soundData);
                for (int i = 0; i < (int)LeaderProfession.Count; i++)
                {
                    EditorGUILayout.BeginVertical("box");
                    Label(((LeaderProfession)i).ToProfession(), Color.cyan);
                    EditorGUILayout.BeginVertical("box");
                    EditDialogFileMenu(dialogData.dialogFileData.tList[i], dialogData.limitRoleType);
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.BeginVertical("box");
                    EditDialogMenu(dialogData.soundData.tList[i]);
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical("box");
                Label("女主角对话数据:",Color.yellow);
                EditModelProfessionMenu(dialogData.dialogFileData1);
                EditSoundProfessionMenu(dialogData.soundData1);
                for (int i = 0; i < (int)LeaderProfession.Count; i++)
                {
                    EditorGUILayout.BeginVertical("box");
                    Label(((LeaderProfession)i).ToProfession(), Color.cyan);
                    EditorGUILayout.BeginVertical("box");
                    EditDialogFileMenu(dialogData.dialogFileData1.tList[i], dialogData.limitRoleType);
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.BeginVertical("box");
                    EditDialogMenu(dialogData.soundData1.tList[i]);
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndVertical();
                break;
            case StoryDialogData.LimitRoleType.Monster:
                EditNPCID(dialogData.dialogFileData.t);
                EditDialogFileMenu(dialogData.dialogFileData.t, dialogData.limitRoleType);
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical("box");
                BoolField("区分男女数据(默认男性)", ref dialogData.isDistinguish);
                EditorGUILayout.BeginVertical("box");
                Label("碰到男主角对话数据:", Color.yellow);
                EditDialogMenu(dialogData.soundData.t);
                EditorGUILayout.EndVertical();
                EditorGUILayout.BeginVertical("box");
                Label("碰到女主角对话数据:", Color.yellow);
                EditDialogMenu(dialogData.soundData1.t);
                EditorGUILayout.EndVertical();
                EditorGUILayout.EndVertical();
                break;
            default:
                break;
        }
    }
    private void EditNPCID(StoryModelData modelData)
    {
        IntField("角色ID:", ref modelData.roleID);
    }
    private void EditDialogFileMenu(StoryModelData modelData, StoryDialogData.LimitRoleType type)
    {
        modelData.roleData.controlType = GetRoleType(type);
        switch (modelData.roleData.controlType)
        {
            case StoryRoleData.ROLETYPE.LEAD:
                BoolField("IsLocal", ref modelData.roleData.isLocal);
                break;
            case StoryRoleData.ROLETYPE.HERO:
                IntField("PathFileResID", ref modelData.roleID);
                break;
            case StoryRoleData.ROLETYPE.ENEMY:
            case StoryRoleData.ROLETYPE.SceneNPC:
                {
                    BoolField("IsLocal", ref modelData.roleData.isLocal);
                    modelData.roleData.npcBirthPositionID = EditorGUILayout.IntField("NPC出生点ID:", modelData.roleData.npcBirthPositionID);
                    modelData.roleData.npcBirthPositionIndex = EditorGUILayout.IntField("NPC出生点Index:", modelData.roleData.npcBirthPositionIndex);
                    EditorGUILayout.Space();
                }
                break;
        }
        modelData.headModelSizePercent = (EditorGUILayout.FloatField("模型比例:", modelData.headModelSizePercent));
        Vector3Field("模型位置：", ref modelData.modelLocalPos);
    }
    private StoryRoleData.ROLETYPE GetRoleType(StoryDialogData.LimitRoleType type)
    {
        switch (type)
        {
            case StoryDialogData.LimitRoleType.Leader:
                return StoryRoleData.ROLETYPE.LEAD;
            case StoryDialogData.LimitRoleType.None:
                return StoryRoleData.ROLETYPE.HERO;
            default:
                return StoryRoleData.ROLETYPE.ENEMY;
        }
    }
    /// <summary>
    /// 编辑不同职业的界面
    /// </summary>
    /// <param name="actionData"></param>
    private void EditProfessionMenu<T>(StoryProfessionData<T> tData) where T : new ()
    {
        if (tData.tList.Count == 0)
        {
            for (int i = 0; i < (int)LeaderProfession.Count; i++)
            {
                tData.leaderProfessionList.Add((LeaderProfession)i);
                tData.tList.Add(new T());
            }
        }
    }
    private void EditModelProfessionMenu(StoryModelProfessionData tData)
    {
        if (tData.tList.Count == 0)
        {
            for (int i = 0; i < (int)LeaderProfession.Count; i++)
            {
                tData.leaderProfessionList.Add((LeaderProfession)i);
                tData.tList.Add(new StoryModelData());
            }
        }
    }
    private void EditSoundProfessionMenu(StorySoundProfessionData tData)
    {
        if (tData.tList.Count == 0)
        {
            for (int i = 0; i < (int)LeaderProfession.Count; i++)
            {
                tData.leaderProfessionList.Add((LeaderProfession)i);
                tData.tList.Add(new StorySoundData());
            }
        }
    }
    /// <summary>
    /// 相机晃动编辑
    /// </summary>
    /// <param name="cameraShakeData"></param>
    private void EditCameraShakeMenu(CameraShakeInfo cameraShakeData)
    {
        FloatField("ShakeTime", ref cameraShakeData.ShakeTime);
        IntField("numberOfShakes", ref cameraShakeData.numberOfShakes);
        Vector3Field("shakeAmount", ref cameraShakeData.shakeAmount);
        Vector3Field("rotationAmount", ref cameraShakeData.rotationAmount);
        FloatField("distance", ref cameraShakeData.distance);
        FloatField("speed", ref cameraShakeData.speed);
        FloatField("decay", ref cameraShakeData.decay);
    }
    /// <summary>
    /// 编辑相机晃动界面
    /// </summary>
    /// <param name="cameraShakeDatas"></param>
    private void EditCameraShakesMenu(List<CameraShakeInfo> cameraShakeDatas)
    {
        int index = 1;
        cameraShakeDatas.ForEach(delegate (CameraShakeInfo data)
        {
            EditorGUILayout.BeginHorizontal();
            GUI.color = Color.green;
            FloatField("ShakeTime" + index.ToString(), ref data.ShakeTime);
            GUI.color = Color.white;
            if (GUILayout.Button("Delete CameraShakeInfo"))
            {
                cameraShakeDatas.Remove(data);
                return;
            }
            EditorGUILayout.EndHorizontal();
            EditCameraShakeMenu(data);
            index++;
        });
        if (GUILayout.Button("Add CameraShakeInfo"))
        {
            cameraShakeDatas.Add(new CameraShakeInfo());
        }
    }
    private void EditCameraBlinkOfAnEyeMenu(CameraBlinkOfAnEyeInfo cameraData)
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        EditCameraBlinkOfAnEyeMenu(cameraData.blinkOfAnEyeList);
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
    }
    private void EditCameraBlinkOfAnEyeMenu(List<CameraBlinkOfAnEyeData> cameraDatas)
    {
        int index = 1;
        cameraDatas.ForEach(delegate (CameraBlinkOfAnEyeData data)
        {
            EditorGUILayout.BeginVertical("box");
            if (GUILayout.Button("删除 眨眼"))
            {
                cameraDatas.Remove(data);
                return;
            }
            EditCameraBlinkOfAnEyeMenu(data);
            EditorGUILayout.EndVertical();
            index++;
        });
        if (GUILayout.Button("添加眨眼"))
            cameraDatas.Add(new CameraBlinkOfAnEyeData());
    }
    private void EditCameraBlinkOfAnEyeMenu(CameraBlinkOfAnEyeData cameraData)
    {
        FloatField("起始等待时间:", ref cameraData.blinkDuration);
        FloatField("眨眼开闭间隔:", ref cameraData.blinkOpenCloseDuration);
        FloatField("眨眼开速度:", ref cameraData.blinkOpenSpeed);
        FloatField("眨眼闭速度:", ref cameraData.blinkCloseSpeed);
    }
    private void EditBlackBackgroundMenu(BlackBackgroundData data)
    {
        EditorGUILayout.BeginVertical("box");
        FloatField("黑幕持续时长:", ref data.duration);
        EditorGUILayout.Space();
        EditDialogMenu(data.dialogData);
        EditorGUILayout.EndVertical();
    }

    private void EditPlayCameraAnimatorMenu(PlayCameraAnimatorData cameraData)
    {
        EditorGUILayout.BeginVertical("box");
        cameraData.cameraPath = StoryEditorUtils.ShowSelectResMenu(ResType.CameraPath, cameraData.cameraPath, "请选择镜头", "请选择镜头", "镜头路径:");
        if (!string.IsNullOrEmpty(cameraData.cameraPath))
        {
            Vector3Field("镜头旋转度:", ref cameraData.cameraAngle);
            TextField("镜头动画名称:", ref cameraData.cameraAnimatorName);
            GUILayout.BeginHorizontal();
            Label("Field of View:");
            cameraData.fieldOfView = GUILayout.HorizontalSlider(cameraData.fieldOfView,1,179);
            GUILayout.EndHorizontal();
            FloatField("                  ", ref cameraData.fieldOfView);
            GUILayout.BeginHorizontal();
            Label("Clipping Planes");
            FloatField(" Near", ref cameraData.nearClippingPlanes);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            Label("                      ");
            FloatField(" Far", ref cameraData.FarClippingPlanes);
            GUILayout.EndHorizontal();
            Vector3Field("声音接收器世界坐标:", ref cameraData.audioListenerPos);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space();
    }
}
