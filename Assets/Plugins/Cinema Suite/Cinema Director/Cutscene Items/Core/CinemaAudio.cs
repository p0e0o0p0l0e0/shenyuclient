// Cinema Suite
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CinemaDirector
{
    [CutsceneItemAttribute("Audio", "Play Audio", typeof(AudioClip), CutsceneItemGenre.AudioClipItem)]
    public class CinemaAudio : TimelineActionFixed
    {
        private bool wasPlaying = false;

#if !NoChange
        public int AudioID = 0;
        public float Volume = 1;
        public bool IsBGM = false;
        public bool IsLoop = false;

        public override void Initialize()
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            if (audio == null)
            {
                audio = gameObject.AddComponent<AudioSource>();
            }

            if (AudioID > 0 && audio.clip == null)
            {
                ResourceRequest mResLoader = new ResourceRequest();

                PathFileResStruct res = ViSealedDB<PathFileResStruct>.Data(AudioID);

                mResLoader.Start(res, (UnityEngine.Object pAsset) =>
                {
                    if (pAsset != null)
                    {
                        GameObject prefab = pAsset as GameObject;
                        AudioSource audioPrefab = prefab.GetComponent<AudioSource>();

                        if (audioPrefab != null)
                        {
                            audio.clip = audioPrefab.clip;
                            audio.loop = IsLoop;
                            audio.volume = Volume;

                            ItemLength = audio.clip.length;
                            OutTime = Mathf.Min(OutTime, ItemLength);
                            Duration = OutTime - InTime;
                        }
                        else
                        {
                            ViDebuger.Warning("res[" + AudioID + "] not find AudioSource");
                        }
                    }
                    else
                        ViDebuger.Warning("load res[" + AudioID + "] failed");

                    mResLoader.End();
                }
                );
            }
        }
#endif

        public void Trigger()
        {
#if !NoChange
            AudioSource audio = gameObject.GetComponent<AudioSource>();

            if (audio != null && audio.clip != null)
            {
                if (!audio.isPlaying)
                {
                    audio.Play();
                }
            }
#endif
        }

        public void End()
        {
            Stop();
        }

        public void UpdateTime(float time, float deltaTime)
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            if (audio != null && audio.clip != null)
            {
                audio.mute = false;
                time = Mathf.Clamp(time, 0, audio.clip.length) + InTime;

                if ((audio.clip.length - time) > 0.0001)
                {
                    if (Cutscene.State == CinemaDirector.Cutscene.CutsceneState.Scrubbing)
                    {
                        audio.time = time;
                    }
                    if (!audio.isPlaying)
                    {
                        audio.time = time;
                        audio.Play();
                    }
                }
            }
        }

        public void Resume()
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            if (audio != null)
            {
                if (wasPlaying)
                {
                    audio.Play();
                }
            }
        }

        public void Pause()
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            if (audio != null)
            {
                wasPlaying = false;
                if (audio.isPlaying)
                {
                    wasPlaying = true;
                }
                
                audio.Pause();
            }
        }

        public override void Stop()
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            if (audio)
                audio.Stop();
        }

        public void SetTime(float audioTime)
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            if (audio != null && audio.clip != null)
            {
                audioTime = Mathf.Clamp(audioTime, 0, audio.clip.length);
                if ((audio.clip.length - audioTime) > 0.0001)
                {
                    audio.time = audioTime;
                }
            }
        }

        public override void SetDefaults(UnityEngine.Object PairedItem)
        {
            AudioClip clip = PairedItem as AudioClip;
            if (clip != null)
            {
                AudioSource source = gameObject.AddComponent<AudioSource>();
                source.clip = clip;

                Firetime = 0;
                Duration = clip.length;
                InTime = 0;
                OutTime = clip.length;
                ItemLength = clip.length;
                source.playOnAwake = false;
            }
        }
    }
}