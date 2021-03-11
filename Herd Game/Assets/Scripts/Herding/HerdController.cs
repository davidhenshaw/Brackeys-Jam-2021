using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public class HerdController : MonoBehaviour
    {
        public Ability ability1;
        public Ability ability2;

        Herd targetHerd;
        Coroutine abilityCoroutine;

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
            }

            // Stampede
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                TriggerAbility(ability2);
            }
        }

        void TriggerAbility(Ability a)
        {
            if (a == null)
                return;

            StartCoroutine(AbilityThenCooldown_co(a));
        }

        IEnumerator AbilityThenCooldown_co(Ability a)
        {
            IEnumerator coroutine = a.TryActivate(targetHerd);

            if (coroutine != null)
            {
                yield return StartCoroutine(coroutine);
                StartCoroutine(a.Cooldown());
            }

            yield return null;
        }
    }
}