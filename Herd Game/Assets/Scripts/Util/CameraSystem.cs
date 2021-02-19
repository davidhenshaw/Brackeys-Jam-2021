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

        public CinemachineTargetGroup targetGroup;

        Herd mainHerd;

        private void Awake()
        {
            cameraAnchor.Transform = Camera.main.transform;
        }

        private void Start()
        {
            mainHerd = mainHerdAnchor.Transform.GetComponent<Herd>();
            mainHerd.AgentAdded += OnHerdAgentAdded;
            mainHerd.AgentRemoved += OnHerdAgentRemoved;
        }

        private void OnEnable()
        {
            //mainHerd.AgentAdded += OnHerdAgentAdded;
        }

        private void OnDisable()
        {
            //mainHerd.AgentAdded -= OnHerdAgentAdded;
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