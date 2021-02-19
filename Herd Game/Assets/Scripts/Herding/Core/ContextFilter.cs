using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public abstract class ContextFilter : ScriptableObject
    {
        public abstract List<Transform> Filter(HerdAgent agent, List<Transform> input);
    }
}