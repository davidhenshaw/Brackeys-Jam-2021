using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public abstract class HerdBehavior : ScriptableObject
    {
        public abstract Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd);
    }
}