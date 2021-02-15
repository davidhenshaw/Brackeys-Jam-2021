using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;

namespace metakazz
{
    public class CameraSystem : MonoBehaviour
    {
        public TransformAnchor cameraAnchor;

        private void Awake()
        {
            cameraAnchor.Transform = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}