using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/Modifyers/Constant Smooth Turn Time")]
    public class TurnTimeModifyer : HerdBehaviorModifyer
    {
        [Range(0.01f, 3)]
        public float speedMod = 1;
        public float smoothTurnTime = 0.5f;

        public override float CalculateMoveModifyer(HerdAgent agent, List<Transform> context, Herd herd)
        {
            agent.smoothTurnTime = this.smoothTurnTime;

            return speedMod;
        }
    }
}