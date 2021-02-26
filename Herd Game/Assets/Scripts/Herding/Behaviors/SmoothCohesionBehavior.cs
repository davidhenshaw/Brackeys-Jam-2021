using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/Smooth Cohesion")]
    public class SmoothCohesionBehavior : FilteredHerdBehavior
    {
        Vector2 currentVelocity;
        public float turnSmoothTime = 0.5f;

        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            //if there are no neighbors, return no adjustment
            if (context.Count == 0)
                return Vector2.zero;

            // Average all context positions
            Vector2 average = Vector2.zero;
            Vector2 movement = Vector2.zero;
            List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);

            if (filteredContext.Count == 0)
                return Vector2.zero;

            foreach (Transform item in filteredContext)
            {
                average += (Vector2)item.position;
            }
            average /= context.Count;
            movement = average - (Vector2)agent.transform.position;

            //movement = Vector2.SmoothDamp(agent.transform.up, movement, ref currentVelocity, turnSmoothTime);

            return movement;
        }

        public override void Initialize()
        {
            //throw new System.NotImplementedException();
        }
    }
}