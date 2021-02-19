using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz{
    public class SameTypeFilter : ContextFilter
    {
        public MonoBehaviour monoBehaviour;

        public override List<Transform> Filter(HerdAgent agent, List<Transform> input)
        {
            List<Transform> filtered = new List<Transform>();
            foreach (Transform item in input)
            {
                HerdAgent itemAgent = item.GetComponent<HerdAgent>();
                if (itemAgent.GetType() == agent.GetType())
                {
                    filtered.Add(item);
                }
            }

            return filtered;
        }
    }
}