using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz
{
    public class HerdSpawner : MonoBehaviour
    {
        [SerializeField] Herd prefab;

        public void Spawn()
        {
            Instantiate(prefab, transform);
        }

        public void Spawn(int count)
        {
            var herd = Instantiate(prefab, transform);
            herd.startingCount = count;
        }
    }
}