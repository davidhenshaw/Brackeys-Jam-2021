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

        public new void Die()
        {
            base.Die();
            deathAudioCue.RaiseEvent();
        }

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    Prey agent = collision.gameObject.GetComponent<Prey>();

        //    if(agent != null)
        //    {
        //        agent.Die();
        //    }
        //}
    }
}