using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz{
    public class HerdAgent : MonoBehaviour
    {
        Collider2D myCollider;
        public Collider2D AgentCollider { get { return myCollider; } }

        // Start is called before the first frame update
        void Start()
        {
            myCollider = GetComponent<Collider2D>();
        }

        // Update is called once per frame
        public void Move(Vector2 velocity)
        {
            transform.up = velocity.normalized;
            transform.position += (Vector3)velocity * Time.deltaTime;
        }
    }
}