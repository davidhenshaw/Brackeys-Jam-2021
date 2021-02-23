using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz{
    public class HerdAgent : MonoBehaviour
    {
        Collider2D myCollider;
        Herd myHerd;
        GameObject icon;

        public Sprite sprite;
        SpriteRenderer directionIndicator;

        public GameObject Icon { get => icon; }
        public Collider2D AgentCollider { get { return myCollider; } }
        public Herd AgentHerd { get => myHerd; }

        private void Awake()
        {
            myCollider = GetComponent<Collider2D>();
            myHerd = GetComponentInParent<Herd>();
            directionIndicator = GetComponentInChildren<SpriteRenderer>();            
        }

        // Start is called before the first frame update
        void Start()
        {
            icon = IconFactory.instance.GenerateIcon(transform, sprite);
        }

        public void SetHerd(Herd h)
        {
            myHerd = h;
        }

        // Update is called once per frame
        public void Move(Vector2 velocity)
        {
            if (velocity.magnitude > 0)
            {
                transform.up = velocity.normalized;
                directionIndicator.enabled = true;
            }
            else
            {
                directionIndicator.enabled = false;
            }


            transform.position += (Vector3)velocity * Time.deltaTime;
        }

        [ContextMenu("Die")]
        public void Die()
        {
            myHerd.RemoveAgent(this);
            myCollider.enabled = false;
            directionIndicator.enabled = false;
        }
    }
}