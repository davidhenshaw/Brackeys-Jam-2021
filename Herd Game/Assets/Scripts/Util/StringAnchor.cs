using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    [CreateAssetMenu(menuName = "Runtime Anchors/String")]
    public class StringAnchor : ScriptableObject
    {
        [HideInInspector]
        public bool isSet = false;

        private string _string;
        public string String
        {
            get { return _string; }
            set
            {
                _string = value;
                isSet = _string != null;
            }
        }

        public void OnDisable()
        {
            _string = null;
            isSet = false;
        }
    }
}