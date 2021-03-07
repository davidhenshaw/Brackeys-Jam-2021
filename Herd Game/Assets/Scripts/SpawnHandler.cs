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
            
        }

        public void OnDifficultyChanged(Difficulty d)
        {
            currDifficulty = d;
        }
    }
}