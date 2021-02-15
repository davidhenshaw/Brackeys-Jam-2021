using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz.Util
{
    public class MouseFollower : MonoBehaviour
    {
        public TransformAnchor mouseAnchor;
        public TransformAnchor cameraAnchor;
        Camera mainCamera;

        private void Start()
        {
            mainCamera = cameraAnchor.Transform.GetComponent<Camera>();    
        }

        private void OnEnable()
        {
            mouseAnchor.Transform = this.transform;
        }

        private void OnDisable()
        {
            mouseAnchor.Transform = null;
        }

        // Update is called once per frame
        void Update()
        {
            //Get mouse position from input system
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            //Set my position to the mouse position
            transform.position = mousePos;
        }
    }
}