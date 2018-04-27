using UnityEditor;
using UnityEngine;
using CinemaDirector;

[CustomEditor(typeof(CinemaAudio))]
public class CinemaAudioInspector : Editor
{
    // Properties
    private SerializedObject cinemaAudio;

    private SerializedProperty firetime;
    private SerializedProperty duration;
    private SerializedProperty inTime;
    private SerializedProperty outTime;
    private SerializedProperty itemLength;
#if !NoChange
    private SerializedProperty audioID;
    private SerializedProperty isBGM;
    private SerializedProperty volume;
    private SerializedProperty isLoop;
#endif

    private const string ERROR_MSG = "CinemaAudio requires an AudioSource component with an assigned Audio Clip.";

    /// <summary>
    /// On inspector enable, load serialized objects
    /// </summary>
    public void OnEnable()
    {
        cinemaAudio = new SerializedObject(this.target);

        this.firetime = cinemaAudio.FindProperty("firetime");
        this.duration = cinemaAudio.FindProperty("duration");
        this.inTime = cinemaAudio.FindProperty("inTime");
        this.outTime = cinemaAudio.FindProperty("outTime");
        this.itemLength = cinemaAudio.FindProperty("itemLength");
#if !NoChange
        this.audioID = cinemaAudio.FindProperty("AudioID");
        this.isBGM = cinemaAudio.FindProperty("IsBGM");
        this.volume = cinemaAudio.FindProperty("Volume");
        this.isLoop = cinemaAudio.FindProperty("IsLoop");
#endif
    }

    /// <summary>
    /// Update and Draw the inspector
    /// </summary>
    public override void OnInspectorGUI()
    {
        cinemaAudio.Update();

        CinemaAudio audio = (target as CinemaAudio);
        AudioSource audioSource = audio.gameObject.GetComponent<AudioSource>();

        EditorGUILayout.PropertyField(firetime);
        EditorGUILayout.PropertyField(duration);
        EditorGUILayout.PropertyField(inTime);
        EditorGUILayout.PropertyField(outTime);

#if !NoChange
        EditorGUILayout.Space();
        GUI.color = Color.green;
        EditorGUILayout.PropertyField(audioID);
        EditorGUILayout.PropertyField(volume);
        EditorGUILayout.PropertyField(isBGM);
        EditorGUILayout.PropertyField(isLoop);
        GUI.color = Color.white;
#else

        if (audioSource == null || audioSource.clip == null)
        {
            EditorGUILayout.HelpBox(ERROR_MSG, MessageType.Error);
        }
#endif
        AudioClip audioClip = audioSource.clip;

        if (audioClip != null)
        {
#if !NoChange
            GUI.color = Color.yellow;
            EditorGUILayout.LabelField("AudioClip Length  ： " + audioClip.length);
            GUI.color = Color.white;
#endif

            if (audioClip.length != itemLength.floatValue)
            {
                itemLength.floatValue = audioClip.length;
                outTime.floatValue = Mathf.Min(outTime.floatValue, itemLength.floatValue);
                duration.floatValue = outTime.floatValue - inTime.floatValue;
            }
        }

        cinemaAudio.ApplyModifiedProperties();
    }
}
