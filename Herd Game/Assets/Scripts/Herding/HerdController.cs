using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public class HerdController : MonoBehaviour
    {
        public Ability ability1;
        public Ability ability2;
        [Space]
        public AudioCueSO stampedeAudioCue;
        public AudioCueSO scatterAudioCue;

        Herd targetHerd;

        private void Awake()
        {
            targetHerd = GetComponent<Herd>();    
        }

        // Update is called once per frame
        void Update()
        {
            // Scatter
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                TriggerAbility(ability1);
                scatterAudioCue.RaiseEvent();
            }

            // Stampede
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TriggerAbility(ability2);
                stampedeAudioCue.RaiseEvent();
            }
        }

        void TriggerAbility(Ability a)
        {
            if (a == null)
                return;

            if(a.IsReady)
            {
                StartCoroutine(a.DoAbility(targetHerd));
                StartCoroutine(a.Cooldown());
            }
        }
    }
}