using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "Runtime Anchors/Float")]
    public class FloatAnchor : ScriptableObject
    {
        [HideInInspector]
        public bool isSet = false;

        private float myValue = float.Epsilon;
        public float Value
        {
            get { return myValue; }
            set
            {
                myValue = value;
                isSet = myValue != float.Epsilon;
            }
        }

        public void OnDisable()
        {
            myValue = float.Epsilon;
            isSet = false;
        }
    }
}