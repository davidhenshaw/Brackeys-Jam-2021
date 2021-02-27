using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public class StampedeAbility : Ability
    {
        public float moveSpeed = 6f;
        float moveSpeedCache;

        public float smoothDampTime = 1f;
        float smoothDampTimeCache;

        public float duration = 3f;

        public override IEnumerator DoAbility(Herd herd)
        {
            yield return new WaitForSeconds(duration);
        }
    }
}