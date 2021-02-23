using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/Modifyers/Neighbor Count")]
    public class NeighborCountModifyer : HerdBehaviorModifyer
    {
        public int minCount;
        public int maxCount;
        [Space]
        public float minModAmount;
        public float maxModAmount;

        public override float CalculateMoveModifyer(HerdAgent agent, List<Transform> context, Herd herd)
        {
            if(context.Count == 0)
                return 1;

            List<Transform> filteredContext = (contextFilter != null) ? contextFilter.Filter(agent, context) : context;

            if (filteredContext.Count < minCount)
                return 1;

            float contextPercentage = Mathf.InverseLerp(minCount, maxCount, filteredContext.Count);

            return Mathf.Lerp(minModAmount, maxModAmount, contextPercentage);
        }
    }
}