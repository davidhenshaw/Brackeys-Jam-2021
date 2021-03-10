using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace metakazz
{
    public class Prey : HerdAgent
    {
        public static event Action<Transform> PredatorTrampled;

        [SerializeField]
        float minPredatorKillSpeed = 6;

        [Range(0,1)]
        [SerializeField]
        float trampleThreshold = 0.95f;
        [Space]
        public AudioCueSO deathAudioCue;

        bool CanTrample(Predator p)
        {
            bool speedReq = currVelocity.magnitude >= minPredatorKillSpeed;

            Vector2 offset = p.transform.position - this.transform.position;
            bool angleReq = Vector2.Dot(currVelocity.normalized, offset.normalized) >= trampleThreshold;


            return speedReq && angleReq;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Predator predator = collision.gameObject.GetComponent<Predator>();

            if (predator != null)
            {
                if (CanTrample(predator))
                {
                    predator.Die();
                    PredatorTrampled?.Invoke(predator.transform);
                }
                else
                {
                    Die();
                }

            }
        }

        public new void Die()
        {
            base.Die();
            deathAudioCue.RaiseEvent();
        }
    }
}