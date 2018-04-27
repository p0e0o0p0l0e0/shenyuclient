using CinemaDirector.Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace CinemaDirector
{
    /// <summary>
    /// Enable the Actor related to this event.
    /// </summary>
    [CutsceneItemAttribute("Particle System", "Stop", CutsceneItemGenre.ActorItem)]
    public class StopParticleSystemEvent : CinemaActorEvent
    {
        /// <summary>
        /// Trigger the particle system to stop.
        /// </summary>
        /// <param name="actor">The actor to be triggered.</param>
        public override void Trigger(GameObject actor)
        {
            if (actor != null)
            {
#if NoChange
                ParticleSystem ps = actor.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Stop();
                }
#else
                ParticleSystem[] psArray = actor.GetComponentsInChildren<ParticleSystem>();

                for (int i = 0; i < psArray.Length; i++)
                {
                    if (psArray[i] != null)
                    {
                        psArray[i].Stop();
                    }
                }
#endif
            }
        }

        /// <summary>
        /// Reverse this event and play the particle system.
        /// </summary>
        /// <param name="actor">The actor to reverse this event on.</param>
        public override void Reverse(GameObject actor)
        {
            if (actor != null)
            {
#if NoChange
                ParticleSystem ps = actor.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Play();
                }
#else
                ParticleSystem[] psArray = actor.GetComponentsInChildren<ParticleSystem>();

                for (int i = 0; i < psArray.Length; i++)
                {
                    if (psArray[i] != null)
                    {
                        psArray[i].Play();
                    }
                }
#endif
            }
        }
    }
}