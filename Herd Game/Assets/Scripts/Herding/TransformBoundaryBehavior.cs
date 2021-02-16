using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;
namespace metakazz{
    [CreateAssetMenu(menuName = "HerdBehavior/Transform Boundary")]
    public class TransformBoundaryBehavior : HerdBehavior
    {
        public TransformAnchor tfAnchor;
        public float radius = 15f;

        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            Vector2 centerOffset = tfAnchor.Transform.position - agent.transform.position;
            float t = centerOffset.magnitude / radius;

            float maxThreshold = 0.9f;
            if (t < maxThreshold)
            {
                return Vector2.zero;
            }

            return centerOffset * t * t;
        }
    }
}