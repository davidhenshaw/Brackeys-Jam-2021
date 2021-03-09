using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace metakazz
{
    public abstract class Ability : ScriptableObject
    {
        public event Action Ready;
        public event Action Activated;
        public event Action CooldownStarted;

        public float coolTime;
        protected bool isReady = true;

        public bool IsReady { get => isReady; }
        public float CooldownTime { get => coolTime; }

        public IEnumerator TryActivate(Herd targetHerd)
        {
            if(isReady)
            {
                Activated?.Invoke();
                isReady = false;
                return DoAbility(targetHerd);
            }

            return null;
        }

        public IEnumerator Cooldown()
        {
            isReady = false;
            CooldownStarted?.Invoke();
            yield return new WaitForSeconds(coolTime);
            Ready?.Invoke();
            isReady = true;
        }

        protected abstract IEnumerator DoAbility(Herd herd);
    }
}