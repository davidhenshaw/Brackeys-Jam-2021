using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public abstract class HerdBehaviorModifyer : ScriptableObject
    {
        public ContextFilter contextFilter;
        public abstract float CalculateMoveModifyer(HerdAgent agent, List<Transform> context, Herd herd);
    }
}