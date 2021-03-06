using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public class AudioHandler : MonoBehaviour
    {
        AudioSource source;
        public AudioCueSO[] cues;

        private void Start()
        {
            source = GetComponent<AudioSource>();
            foreach(AudioCueSO a in cues)
            {
                a.OnEventRaised += PlayClip;
            }
        }

        void PlayClip(AudioCue cue)
        {
            source.PlayOneShot(cue.clip);
        }
    }
}