using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "Herd Filter/Different Herd & Physics Layer")]
    public class DiffHerdSameLayerFilter : ContextFilter
    {
        public LayerMask layerMask;

        public override List<Transform> Filter(HerdAgent agent, List<Transform> input)
        {
            List<Transform> filtered = new List<Transform>();

            foreach (Transform item in input)
            {
                HerdAgent otherAgent = item.GetComponent<HerdAgent>();

                //If the item's layer matches at least one layer of my layerMask
                bool matchesLayer = layerMask == (layerMask | 1 << item.gameObject.layer);
                // If the item is not a HerdAgent at all or if it is not in the same herd
                bool diffHerd = (otherAgent == null) || (otherAgent.AgentHerd != agent.AgentHerd);

                if (matchesLayer && diffHerd)
                {
                    filtered.Add(item);
                }
            }

            return filtered;
        }
    }
}