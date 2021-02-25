using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "HerdBehavior/Recruitment")]
    public class RecruitmentBehavior : FilteredHerdBehavior
    {
        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);

            foreach (Transform item in filteredContext)
            {
                HerdAgent itemAgent = item.GetComponent<HerdAgent>();

                //Remove from old herd if it had one
                if(itemAgent.AgentHerd != null)
                    itemAgent.AgentHerd.RemoveAgent(itemAgent);

                //Add to the new herd
                agent.AgentHerd.AddAgent(itemAgent);
            }

            return Vector2.zero;
        }

        public override void Initialize()
        {

        }

    }
}