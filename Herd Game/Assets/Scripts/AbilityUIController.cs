using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz{
    public class AbilityUIController : MonoBehaviour
    {
        [SerializeField] Ability ability;

        // Start is called before the first frame update
        void Start()
        {
            ability.Activated += OnActivate;
            ability.CooldownStarted += OnCooldown;
            ability.Ready += OnReady;
        }

        private void OnDisable()
        {
            ability.Activated -= OnActivate;
            ability.CooldownStarted -= OnCooldown;
            ability.Ready -= OnReady;
        }

        void OnReady()
        {
            Debug.Log(ability.name + " ready!");
        }

        void OnActivate()
        {
            Debug.Log(ability.name + " activated!");
        }

        void OnCooldown()
        {
            Debug.Log(ability.name + " availible in " + ability.CooldownTime + " seconds");
        }
    }
}