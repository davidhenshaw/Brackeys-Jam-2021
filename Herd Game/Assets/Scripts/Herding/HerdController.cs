using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz{
    public class HerdController : MonoBehaviour
    {
        public Ability scatterAbility;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                if(scatterAbility != null)
                    scatterAbility.TryActivate();
            }
        }
    }
}