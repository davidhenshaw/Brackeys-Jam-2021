using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz{
    public class HerdController : MonoBehaviour
    {
        public Ability scatterAbility;
        Herd targetHerd;

        private void Awake()
        {
            targetHerd = GetComponent<Herd>();    
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                TriggerAbility(scatterAbility);
            }
        }

        void TriggerAbility(Ability a)
        {
            if (a == null)
                return;

            if(a.IsReady)
            {
                StartCoroutine(a.DoAbility(targetHerd));
                StartCoroutine(a.Cooldown());
            }
        }
    }
}