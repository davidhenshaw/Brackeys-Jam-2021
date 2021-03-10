using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "Context Filter/Physics Layer")]
    public class PhysicsLayerFilter : ContextFilter
    {
        public LayerMask layerMask;

        public override List<Transform> Filter(HerdAgent agent, List<Transform> input)
        {
            List<Transform> filtered = new List<Transform>();

            foreach (Transform item in input)
            {
                //If the item's layer matches at least one layer of my layerMask
                if(layerMask == (layerMask | 1 << item.gameObject.layer))
                {
                    filtered.Add(item);
                }
            }

            return filtered;
        }
    }
}