using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace metakazz{
    public class FloatAnchorDisplay : MonoBehaviour
    {
        TMP_Text tmpText;
        public FloatAnchor anchor;

        private void Awake()
        {
            tmpText = GetComponent<TMP_Text>();
        }

        // Update is called once per frame
        void Update()
        {
            if(anchor != null)
                tmpText.text = anchor.Value.ToString();
        }
    }
}