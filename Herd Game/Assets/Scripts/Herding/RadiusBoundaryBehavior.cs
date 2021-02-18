using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/Radius Boundary")]
    public class RadiusBoundaryBehavior : HerdBehavior
    {
        public Vector2 center;
        public float radius = 15f;

        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            Vector2 centerOffset = center - (Vector2)agent.transform.position;
            float t = centerOffset.magnitude / radius;
            
            float maxThreshold = 0.9f;            
            if(t < maxThreshold)
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