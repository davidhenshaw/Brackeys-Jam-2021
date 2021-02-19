using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;
namespace metakazz
{
    public class HerdCounter : MonoBehaviour
    {
        public TransformAnchor herdAnchor;

        /*Events*/[Space]
        public IntEventSO AgentEntered;
        public IntEventSO AgentExited;

        Herd herd;
        int _count;

        // Start is called before the first frame update
        void Start()
        {
            herd = herdAnchor.Transform.GetComponent<Herd>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            HerdAgent agent = collision.gameObject.GetComponent<HerdAgent>();

            if(agent != null && agent.AgentHerd == herd)
            {
                _count++;
                AgentEntered.RaiseEvent(_count);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            HerdAgent agent = collision.gameObject.GetComponent<HerdAgent>();

            if (agent != null && agent.AgentHerd == herd)
            {
                _count = Mathf.Clamp(_count - 1, 0, int.MaxValue);
                AgentExited.RaiseEvent(_count);
            }
        }
    }
}