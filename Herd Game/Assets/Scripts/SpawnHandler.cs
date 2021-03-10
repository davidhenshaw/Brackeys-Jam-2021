using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;
namespace metakazz
{
    public class SpawnHandler : MonoBehaviour
    {
        public TransformAnchor mainHerdAnchor;
        public TransformAnchor targetGroupAnchor;
        Transform mainHerd;
        Transform groupTransform;

        public int targetAgentCount = 5;
        public float minSpawnDistance = 35;

        [Space]

        public float maxPerSpawner = 3;

        [SerializeField] List<HerdSpawner> spawners;

        int currAgentCount;
        Difficulty currDifficulty;

        // Start is called before the first frame update
        void Start()
        {
            GameManager.instance.DifficultyChanged += OnDifficultyChanged;

            if(mainHerdAnchor)
            {
                mainHerd = mainHerdAnchor.Transform;
            }

            if (targetGroupAnchor)
            {
                groupTransform = targetGroupAnchor.Transform;
            }

            InitializeSpawners();
        }

        // Update is called once per frame
        void Update()
        {
            if(currAgentCount < targetAgentCount)
            {
                SpawnHerds(targetAgentCount - currAgentCount);
            }
        }

        private void InitializeSpawners()
        {
            foreach(HerdSpawner spawner in spawners)
            {
                spawner.HerdSpawned += OnHerdSpawned;
            }
        }

        void SpawnHerds(int numAgents)
        {
            //choose a spawner 
            // loop through all spawners
            // find distance from spawner to player's herd
            // if distance is above minimum, tell spawner to spawn

            int numLeft = numAgents;

            //Generate a list of numbers
            List<int> numbers = new List<int>();
            for (int i = 0; i < spawners.Count; i++)
                numbers.Add(i);

            //Randomly pick from the remaining numbers in the list
            // to choose a spawner
            while(numbers.Count > 0 && numLeft > 0)
            {
                int rand = UnityEngine.Random.Range(0, numbers.Count);   //The randomizer will never pick "1" if numbers.Count is 1

                float dist = Vector3.Distance(groupTransform.position, spawners[rand].transform.position);
                bool canSpawn = dist > minSpawnDistance;

                if (canSpawn)
                {
                    int numToSpawn = Mathf.FloorToInt(Mathf.Clamp(numLeft, 0, maxPerSpawner));
                    spawners[rand].Spawn(numToSpawn);

                    numLeft -= numToSpawn;
                }

                numbers.RemoveAt(rand);
            }
        }

        public void OnDifficultyChanged(Difficulty d)
        {
            currDifficulty = d;
        }

        public void OnHerdSpawned(Herd h)
        {
            h.AgentAdded += OnAgentAdded;
            h.AgentRemoved += OnAgentLost;

            //currAgentCount += h.startingCount;
        }

        public void OnAgentAdded(HerdAgent a)
        {
            currAgentCount += 1;
        }

        public void OnAgentLost(HerdAgent a)
        {
            currAgentCount -= 1;
        }
    }
}