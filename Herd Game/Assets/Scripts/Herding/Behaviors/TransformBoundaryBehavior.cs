using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;
using UnityEditor;

namespace metakazz{
    [CreateAssetMenu(menuName = "HerdBehavior/Transform Boundary")]
    public class TransformBoundaryBehavior : HerdBehavior
    {
        //public TransformAnchor tfAnchor;
        public TransformEventSO leftClickEvent;
        public float radius = 15f;
        [Range(0,1)]
        public float maxThreshold = 0.9f;

        [HideInInspector]
        public Vector2 targetPosition = Vector2.zero;

        public override void Initialize()
        {
            leftClickEvent.OnEventRaised += OnLeftClick;
            targetPosition = Vector2.zero;
        }

        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            Vector2 centerOffset = targetPosition - (Vector2)agent.transform.position;
            float t = centerOffset.magnitude / radius;


            if (t < maxThreshold)
            {
                return Vector2.zero;
            }


            return centerOffset * t * t;
        }

        public void OnLeftClick(Transform t)
        {
            targetPosition = t.position;
        }
    }
}