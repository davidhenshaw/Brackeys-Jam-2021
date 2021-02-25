using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public class BehaviorSwapAbility : Ability
    {
        HerdBehavior behaviorCache;
        public HerdBehavior newBehavior;
        Herd targetHerd;
        [Space]
        public float duration;
        float elapsed;
        bool isActive;

        private void Awake()
        {
            targetHerd = GetComponent<Herd>();
            behaviorCache = targetHerd.behavior;
        }

        protected override void DoAbility()
        {
            behaviorCache = targetHerd.behavior;

            targetHerd.behavior = newBehavior;
            isActive = true;
            StartCoroutine(AbilityDuration_co(duration));
        }

        IEnumerator AbilityDuration_co(float time)
        {
            yield return new WaitForSeconds(time);
            targetHerd.behavior = behaviorCache;
        }

    }
}