using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/Intimidate")]
    public class IntimidateBehavior : FilteredHerdBehavior
    {
        public int minToIntimidate = 4;
        public float minThreshold = 0.8f;

        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            //if there are no neighbors, return no adjustment
            if (context.Count < minToIntimidate)
                return Vector2.zero;

            // Average all context positions
            Vector2 averageOffset = Vector2.zero;
            Vector2 averageVelocity = Vector2.zero;

            List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);

            if (filteredContext.Count < minToIntimidate)
                return Vector2.zero;

            foreach (Transform item in filteredContext)
            {
                Vector2 offset = agent.transform.position - item.position;
                averageOffset += offset;

                HerdAgent a = item.GetComponent<HerdAgent>();

                if(a != null)
                    averageVelocity += a.Velocity;
            }

            averageOffset /= filteredContext.Count;
            averageVelocity /= filteredContext.Count;

            if(Vector2.Dot(averageVelocity, averageOffset) > minThreshold)
            {
                //Return a vector perpendicular to the average velocity 
                // to avoid the "intimidating" object
                return Vector2.Perpendicular(averageVelocity);
            }

            return Vector2.zero;
        }

        public override void Initialize()
        {
        }
    }
}