using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz{
    public class HerdAgent : MonoBehaviour
    {
        Collider2D myCollider;
        Herd myHerd;
        public Collider2D AgentCollider { get { return myCollider; } }
        public Herd AgentHerd { get => myHerd; }

        // Start is called before the first frame update
        void Start()
        {
            myCollider = GetComponent<Collider2D>();
            myHerd = GetComponentInParent<Herd>();
        }

        // Update is called once per frame
        public void Move(Vector2 velocity)
        {
            if(velocity.magnitude > 0)
                transform.up = velocity.normalized;

            transform.position += (Vector3)velocity * Time.deltaTime;
        }

        [ContextMenu("Die")]
        public void Die()
        {
            myHerd.RemoveAgent(this);
        }
    }
}