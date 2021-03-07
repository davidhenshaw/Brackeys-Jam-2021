using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/Context Audio Cue")]
    public class ContextAudioCueBehavior : FilteredHerdBehavior
    {
        public int emitAtCount = 1;
        public AudioCueSO audioCue;

        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            //if there are no neighbors, return no adjustment
            if (context.Count == 0)
                return Vector2.zero;

            Predator predator = (Predator)agent;

            if (predator == null)
                return Vector2.zero;

            List<Transform> filteredContext = (filter == null ) ? context : filter.Filter(agent, context);

            if(filteredContext.Count >= emitAtCount)
            {
                predator.PreySpotted = true;
            }
            else
            {
                predator.PreySpotted = false;
            }

            return Vector2.zero;
        }

        public override void Initialize()
        {
            //throw new System.NotImplementedException();
        }
    }
}