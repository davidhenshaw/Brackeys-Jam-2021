using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [RequireComponent(typeof(AudioSource))]
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

        private void OnDestroy()
        {
            foreach (AudioCueSO a in cues)
            {
                a.OnEventRaised -= PlayClip;
            }
        }

        void PlayClip(AudioCue cue)
        {
            source.loop = cue.loop;

            if (cue.oneShot)
            {
                source.PlayOneShot(cue.clip);
            }
            else
            {
                source.clip = cue.clip;
                source.Play();
            }

        }
    }
}