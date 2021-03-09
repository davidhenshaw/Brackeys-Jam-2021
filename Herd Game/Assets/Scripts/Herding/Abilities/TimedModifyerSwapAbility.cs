﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "Herd Ability/Timed Modifyer Swap")]
    public class TimedModifyerSwapAbility : Ability
    {
        HerdBehaviorModifyer modifyerCache;
        public HerdBehaviorModifyer newModifyer;
        [Space]
        float elapsed;
        bool isActive;

        private void OnEnable()
        {
            isReady = true;
        }

        protected override IEnumerator DoAbility(Herd targetHerd)
        {
            modifyerCache = targetHerd.modifyer;

            targetHerd.modifyer = newModifyer;
            isActive = true;

            yield return new WaitForSeconds(duration);

            isActive = false;
            isReady = true;
            targetHerd.modifyer = modifyerCache;
        }
    }
}