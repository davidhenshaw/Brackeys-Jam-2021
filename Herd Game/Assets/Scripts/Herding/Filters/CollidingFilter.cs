using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "Context Filter/Colliding")]
    public class CollidingFilter : ContextFilter
    {
        public LayerMask layerMask;

        public override List<Transform> Filter(HerdAgent agent, List<Transform> input)
        {
            List<Transform> filtered = new List<Transform>();

            foreach (Transform item in input)
            {
                Collider2D otherAgent = item.GetComponent<Collider2D>();

                //If the item's layer matches at least one layer of my layerMask
                bool matchesLayer = layerMask == (layerMask | 1 << item.gameObject.layer);
                bool isTouching = (otherAgent != null) && (agent.AgentCollider.IsTouching(otherAgent));

                if (matchesLayer && isTouching)
                {
                    filtered.Add(item);
                }
            }

            return filtered;
        }
    }
}