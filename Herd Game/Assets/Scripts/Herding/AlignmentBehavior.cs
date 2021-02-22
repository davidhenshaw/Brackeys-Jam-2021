using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/Alignment")]
    public class AlignmentBehavior : FilteredHerdBehavior
    {
        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            //if there are no neighbors, maintain current heading
            if (context.Count == 0)
                return agent.transform.up;

            // Average all context alignments
            Vector2 alignmentMove = agent.transform.up;

            List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);

            foreach (Transform item in filteredContext)
            {
                alignmentMove += (Vector2)item.transform.up;
            }
            alignmentMove /= context.Count;

            return alignmentMove.normalized;
        }

        public override void Initialize()
        {
            //throw new System.NotImplementedException();
        }
    }
}