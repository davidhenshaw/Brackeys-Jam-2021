using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/Modifyers/Composite")]
    public class CompositeModifyer : HerdBehaviorModifyer
    {
        public HerdBehaviorModifyer[] modifyers;


        public override float CalculateMoveModifyer(HerdAgent agent, List<Transform> context, Herd herd)
        {
            float finalMod = 1;

            for (int i = 0; i < modifyers.Length; i++)
            {
                float moveMod = Mathf.Abs(modifyers[i].CalculateMoveModifyer(agent, context, herd));

                finalMod += (moveMod - 1);
            }

            return finalMod;
        }
    }
}