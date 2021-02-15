using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/SmoothCohesion")]
    public class SmoothCohesionBehavior : HerdBehavior
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
            foreach (Transform item in context)
            {
                average += (Vector2)item.position;
            }
            average /= context.Count;
            movement = average - (Vector2)agent.transform.position;

            movement = Vector2.SmoothDamp(agent.transform.up, movement, ref currentVelocity, turnSmoothTime);

            return movement;
        }
    }
}