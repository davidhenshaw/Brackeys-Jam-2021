using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/Fixed Boundary")]
    public class FixedBoundaryBehavior : HerdBehavior
    {
        public Vector2 center;
        public float radius = 15f;
        [Space]
        public float maxThreshold = 0.9f;

        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            Vector2 centerOffset = center - (Vector2)agent.transform.position;
            float t = centerOffset.magnitude / radius;

            if (t < maxThreshold)
            {
                return Vector2.zero;
            }

            return centerOffset * t * t;
        }

        public override void Initialize()
        {
            //throw new System.NotImplementedException();
        }
    }
}