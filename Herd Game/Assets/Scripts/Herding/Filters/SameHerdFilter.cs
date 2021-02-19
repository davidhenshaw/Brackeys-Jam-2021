using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName ="Herd Filter/Same Flock")]
    public class SameHerdFilter : ContextFilter
    {
        public override List<Transform> Filter(HerdAgent agent, List<Transform> input)
        {
            List<Transform> filtered = new List<Transform>();
            foreach(Transform item in input)
            {
                HerdAgent itemAgent = item.GetComponent<HerdAgent>();
                if(itemAgent != null && itemAgent.AgentHerd == agent.AgentHerd)
                {
                    filtered.Add(item);
                }
            }

            return filtered;
        }
    }
}