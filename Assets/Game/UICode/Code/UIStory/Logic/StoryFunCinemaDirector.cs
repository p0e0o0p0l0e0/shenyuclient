using UnityEngine;
using System.Collections;

public class StoryFunCinemaDirector : StoryFunBase
{
    private StoryFunctionCinemaDirectorData _cinemaDirectorData;
    private StoryCinemaDirector cinemaDirector;

    public override void Run(StoryFunctionData data, VoidDelegate callBack)
    {
        base.Run(data, callBack);

        _cinemaDirectorData = data.cinemaDirectorData;

        if (Init())
        {
            cinemaDirector.Play();
        }
        else
        {
            UConsole.LogError("StoryFunCinemaDirector Init faild.path:" + _cinemaDirectorData.fileData.prefabPath);
            EndCallBack();
        }
    }

    public override void Stop()
    {
        if (cinemaDirector.IsNotNull())
        {
            cinemaDirector.Stop();

            cinemaDirector.Clear();
        }
    }

    private bool Init()
    {
        string path = _cinemaDirectorData.fileData.prefabPath;

        path = path.Replace("Assets/Resources/", "");
        path = path.Replace(".prefab", "");

       GameObject obj = StoryManager.GetInstance.LoadGameObject(path);

        if (obj.IsNotNull())
        {
            cinemaDirector = obj.GetComponent<StoryCinemaDirector>();

            if (cinemaDirector.IsNotNull())
            {
                if (cinemaDirector.Init(End))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void End()
    {
        cinemaDirector.Clear();

        cinemaDirector = null;

        EndCallBack();
    }
}
