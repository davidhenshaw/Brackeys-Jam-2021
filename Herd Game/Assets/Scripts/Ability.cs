using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public abstract class Ability : ScriptableObject
    {
        public float coolTime;
        protected bool isReady = true;

        public bool IsReady { get => isReady; }

        public bool TryActivate(Herd targetHerd)
        {
            if(isReady)
            {
                DoAbility(targetHerd);
                return true;
            }

            return false;
        }

        public IEnumerator Cooldown()
        {
            isReady = false;
            yield return new WaitForSeconds(coolTime);
            isReady = true;
        }

        public abstract IEnumerator DoAbility(Herd herd);
    }
}