using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;
namespace metakazz
{
    public class SpawnHandler : MonoBehaviour
    {
        [SerializeField] List<HerdSpawner> spawners;

        TransformAnchor mainHerdAnchor;

        int targetAgentCount;

        int currAgentCount;
        Difficulty currDifficulty;

        // Start is called before the first frame update
        void Start()
        {
            GameManager.instance.DifficultyChanged += OnDifficultyChanged;
        }

        // Update is called once per frame
        void Update()
        {
            if(currAgentCount < targetAgentCount)
            {
                SpawnHerds(targetAgentCount - currAgentCount);
            }
        }

        void SpawnHerds(int numAgents)
        {
            //choose a spawner 
                // loop through all spawners
                // find distance from spawner to player's herd
                // if distance is above minimum, tell spawner to spawn
        }

        public void OnDifficultyChanged(Difficulty d)
        {
            currDifficulty = d;
        }
    }
}