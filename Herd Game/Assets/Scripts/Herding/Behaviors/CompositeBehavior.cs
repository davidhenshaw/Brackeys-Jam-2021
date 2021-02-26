using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/Composite")]
    public class CompositeBehavior : HerdBehavior
    {
        public HerdBehavior[] behaviors;
        [HideInInspector]
        public float[] weights;

        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            Vector2 movement = Vector2.zero;

            for(int i = 0; i < behaviors.Length; i++)
            {
                Vector2 weightedMove = behaviors[i].CalculateMove(agent, context, herd) * weights[i];

                movement += weightedMove;
            }

            return movement.normalized;
        }

        public override void Initialize()
        {
            foreach(HerdBehavior hb in behaviors)
            {
                hb.Initialize();
            }
        }
    }
}