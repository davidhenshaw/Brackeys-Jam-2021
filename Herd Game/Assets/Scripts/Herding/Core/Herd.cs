using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;

namespace metakazz{

    public class Herd : MonoBehaviour
    {
        [SerializeField] HerdAgent agentPrefab;
        List<HerdAgent> herdAgents = new List<HerdAgent>();
        public HerdBehavior behavior;
        [Range(0, 100)]
        public int startingCount = 10;
        [Range(0.001f, 10)]
        public float agentDensity = 0.2f;
        [Range(0, 5)]
        public float neighborRadius;
        [Range(0, 2)]
        public float avoidRadius;
        [Range(1, 10)]
        public float speedMultiplier;
        [Range(0, 20)]
        public float maxSpeed;

        public float SquareAvoidanceRadius { get => avoidRadius; }
        public int AgentCount { get => GetComponentsInChildren<HerdAgent>().Length; }

        /*Events*/
        public event Action<HerdAgent> AgentAdded;
        public event Action<HerdAgent> AgentRemoved;

        /*Anchors*/ [Space]
        public TransformAnchor mainHerdAnchor;

        private void Awake()
        {
            if(mainHerdAnchor != null)
            {
                mainHerdAnchor.Transform = transform;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            if(startingCount > 0)
            {
                GenerateAgents();
                InitializeBehaviors();
            }

        }

        // Update is called once per frame
        void Update()
        {
            ApplyAgentBehaviors();
        }

        public void AddAgent(HerdAgent ha)
        {
            herdAgents.Add(ha);
            ha.transform.SetParent(this.transform);
            ha.SetHerd(this);
            AgentAdded?.Invoke(ha);
        }

        public void RemoveAgent(HerdAgent ha)
        {
            herdAgents.Remove(ha);
            ha.transform.SetParent(null);
            AgentRemoved?.Invoke(ha);
        }

        private void InitializeBehaviors()
        {
            behavior.Initialize();
        }

        private void ApplyAgentBehaviors()
        {
            foreach (HerdAgent agent in herdAgents)
            {
                List<Transform> context = GetNearbyObjects(agent);

                //FOR DEBUGGING ONLY
                //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 4f);

                Vector2 move = behavior.CalculateMove(agent, context, this);

                move *= speedMultiplier;
                move = ClampSquared(move, maxSpeed);

                agent.Move(move);
            }
        }

        private void GenerateAgents()
        {
            for (int i = 0; i < startingCount; i++)
            {
                HerdAgent newAgent = Instantiate(
                    agentPrefab,
                    UnityEngine.Random.insideUnitCircle * startingCount * (1/agentDensity),
                    Quaternion.Euler(Vector3.forward * UnityEngine.Random.Range(0f, 360f)),
                    transform
                    );
                newAgent.name = "Agent " + i;
                newAgent.SetHerd(this);
                herdAgents.Add(newAgent);
                AgentAdded?.Invoke(newAgent);
            }
        }

        private Vector2 ClampSquared(Vector2 input, float max)
        {
            Vector2 ret = input;

            if(input.sqrMagnitude > (max * max))
            {
                ret = ret.normalized * max;
            }

            return ret;
        }

        private List<Transform> GetNearbyObjects(HerdAgent agent)
        {
            List<Transform> context = new List<Transform>();
            Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
            foreach(Collider2D c in contextColliders)
            {
                if(c != agent.AgentCollider)
                {
                    context.Add(c.transform);
                }
            }

            return context;
        }
    }

}