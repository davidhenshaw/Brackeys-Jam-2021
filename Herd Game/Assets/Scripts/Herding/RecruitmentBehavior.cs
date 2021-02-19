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

                agent.AgentHerd.AddAgent(itemAgent);
            }

            return Vector2.zero;
        }

        public override void Initialize()
        {

        }

    }
}