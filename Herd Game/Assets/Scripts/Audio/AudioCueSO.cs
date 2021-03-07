using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace metakazz
{
    [CreateAssetMenu(menuName ="Audio Cue")]
    public class AudioCueSO : ScriptableObject
    {
        public AudioCue audioCue;
        public UnityAction<AudioCue> OnEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(audioCue);
        }
    }

    [Serializable]
    public struct AudioCue
    {
        public AudioClip clip;
        public bool oneShot;
        public bool loop;
    }
}