using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz{
    public abstract class Ability : MonoBehaviour
    {
        public float coolTime;
        bool isReady = true;

        public bool IsReady { get => isReady; }

        Coroutine cooldownCoroutine;

        public bool TryActivate()
        {
            if(isReady)
            {
                DoAbility();

                cooldownCoroutine = StartCoroutine(Cooldown_co(coolTime));

                return true;
            }

            return false;
        }

        IEnumerator Cooldown_co(float time)
        {
            isReady = false;
            yield return new WaitForSeconds(time);
            isReady = true;
        }

        protected abstract void DoAbility();
    }
}