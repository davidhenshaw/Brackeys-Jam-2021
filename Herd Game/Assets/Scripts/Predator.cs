using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz{
    public class Predator : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            HerdAgent agent = collision.gameObject.GetComponent<HerdAgent>();

            if(agent != null)
            {
                agent.Die();
            }
        }
    }
}