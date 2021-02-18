using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;

namespace metakazz{
    [RequireComponent(typeof(LineRenderer))]
    public class CircleDrawer : MonoBehaviour
    {
        LineRenderer lineRenderer;
        public TransformEventSO centerSO;
        [Space]
        public int vertexCount;
        public float radius;
        Transform center;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();    
        }

        private void Start()
        {
            if(centerSO != null)
                centerSO.OnEventRaised += OnLeftClick;
        }

        private void Update()
        {
            //Draw();
        }

        void OnLeftClick(Transform t)
        {
            center = t;
            Draw();
        }

        void Draw()
        {
            float deltaAngle = 360/ (float)vertexCount;
            float angle = 0;

            Vector3[] positions = new Vector3[vertexCount];

            for(int i = 0; i < vertexCount; i++)
            {
                angle = deltaAngle * i + 1;
                Vector3 vertDirection = Quaternion.Euler(0, 0, angle) * Vector3.left;

                Vector3 vertPosition = center.position + vertDirection * radius;

                positions[i] = vertPosition;
            }
            lineRenderer.positionCount = vertexCount;
            lineRenderer.SetPositions(positions);
        }
    }
}