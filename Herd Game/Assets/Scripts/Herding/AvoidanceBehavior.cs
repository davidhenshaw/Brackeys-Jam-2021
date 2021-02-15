using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz{
    [CreateAssetMenu(menuName = "HerdBehavior/Avoidance")]
    public class AvoidanceBehavior : HerdBehavior
    {
        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            //if there are no neighbors, return no adjustment
            if (context.Count == 0)
                return Vector2.zero;

            // Average all context positions
            int numAvoid = 0;
            Vector2 average = Vector2.zero;
            foreach (Transform item in context)
            {
                Vector2 avoidOffset = agent.transform.position - item.position;
                bool inPersonalSpace = avoidOffset.sqrMagnitude < herd.SquareAvoidanceRadius;
                if (inPersonalSpace)
                {
                    numAvoid++;
                    average += avoidOffset;
                }
            }

            if(numAvoid > 0)
                average /= numAvoid;


            return average;
        }
    }
}