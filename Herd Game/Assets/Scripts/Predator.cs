using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public class Predator : HerdAgent
    {
        float minPreyKillSpeed = 3;
        [Space]
        public AudioCueSO deathAudioCue;
        public AudioCueSO lockOnAudioCue;

        bool prevPreySpotted = false;
        bool preySpotted = false;
        public bool PreySpotted { set => preySpotted = value; get => preySpotted; }

        public new void Die()
        {
            base.Die();
            deathAudioCue.RaiseEvent();
        }

        private void Update()
        {
            if( !prevPreySpotted && preySpotted )
            {
                lockOnAudioCue.RaiseEvent();
            }

            prevPreySpotted = preySpotted;
        }


    }
}