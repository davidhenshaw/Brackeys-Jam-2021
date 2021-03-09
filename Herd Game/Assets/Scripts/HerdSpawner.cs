using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace metakazz
{
    public class HerdSpawner : MonoBehaviour
    {
        public event Action<Herd> HerdSpawned;

        [SerializeField] Herd prefab;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var herd = Instantiate(prefab, transform);

            HerdSpawned?.Invoke(herd);
        }
        
        public void Spawn(int count=5)
        {
            var herd = Instantiate(prefab, transform);
            herd.startingCount = count;

            HerdSpawned?.Invoke(herd);
        }
    }
}