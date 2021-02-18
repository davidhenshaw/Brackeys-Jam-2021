using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;

namespace metakazz{
    public class GameManager : MonoBehaviour
    {
        public TransformAnchor mainHerdAnchor;
        Herd mainHerd;

        public int minHerdMembers = 6;
        public int maxHerdMembers = 10;

        /*Events*/
        public VoidEventSO LoseEvent;

        // Start is called before the first frame update
        void Start()
        {
            mainHerd = mainHerdAnchor.Transform.GetComponent<Herd>();
            mainHerd.AgentRemoved += OnHerdAgentLost;
        }

        void OnHerdAgentLost(HerdAgent a)
        {
            if(mainHerd.AgentCount < minHerdMembers)
            {
                TriggerLose();
            }
        }

        void TriggerLose()
        {
            LoseEvent.RaiseEvent();
        }
    }
}