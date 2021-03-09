using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "Herd Ability/Timed Behavior Swap")]
    public class TimedBehaviorSwapAbility : Ability
    {
        HerdBehavior behaviorCache;
        public HerdBehavior newBehavior;
        [Space]
        float elapsed;
        bool isActive;

        private void OnEnable()
        {
            isReady = true;
        }

        protected override IEnumerator DoAbility(Herd targetHerd)
        {
            behaviorCache = targetHerd.behavior;

            targetHerd.behavior = newBehavior;
            isActive = true;

            yield return new WaitForSeconds(duration);

            isActive = false;
            isReady = true;
            targetHerd.behavior = behaviorCache;
        }
    }
}