using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public class HerdSpawner : MonoBehaviour
    {
        [SerializeField] Herd prefab;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            Instantiate(prefab, transform);
        }
        
        public void Spawn(int count=5)
        {
            var herd = Instantiate(prefab, transform);
            herd.startingCount = count;
        }
    }
}