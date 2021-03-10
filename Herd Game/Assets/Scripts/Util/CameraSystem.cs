using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;
using Cinemachine;

namespace metakazz
{
    public class CameraSystem : MonoBehaviour
    {
        public TransformAnchor cameraAnchor;
        public TransformAnchor mainHerdAnchor;
        [Space]
        public CinemachineTargetGroup targetGroup;
        public TransformAnchor targetGroupAnchor;

        Herd mainHerd;

        private void Awake()
        {
            cameraAnchor.Transform = Camera.main.transform;
            targetGroupAnchor.Transform = targetGroup.transform;
        }

        private void Start()
        {
            if(mainHerdAnchor.Transform != null)
                mainHerd = mainHerdAnchor.Transform.GetComponent<Herd>();

            if (mainHerd != null)
            {
                mainHerd.AgentAdded += OnHerdAgentAdded;
                mainHerd.AgentRemoved += OnHerdAgentRemoved;

                AddExistingAgents(mainHerd);
            }
        }

        private void OnDisable()
        {
            mainHerd.AgentAdded -= OnHerdAgentAdded;
            mainHerd.AgentRemoved -= OnHerdAgentRemoved;
        }

        void AddExistingAgents(Herd h)
        {
            foreach(HerdAgent a in h.Agents)
            {
                targetGroup.AddMember(a.transform, 1, 0);
            }
        }

        public void OnHerdAgentAdded(HerdAgent a)
        {
            targetGroup.AddMember(a.transform, 1, 0);
        }

        public void OnHerdAgentRemoved(HerdAgent a)
        {
            targetGroup.RemoveMember(a.transform);
        }
    }
}