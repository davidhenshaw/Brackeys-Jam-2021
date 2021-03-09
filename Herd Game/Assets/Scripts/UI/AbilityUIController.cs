using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace metakazz{
    public class AbilityUIController : MonoBehaviour
    {
        [SerializeField] Ability ability;

        [SerializeField] List<AbilityUIEffect> effects;


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

            foreach(AbilityUIEffect e in effects)
            {
                e.OnReady();
            }
        }

        void OnActivate()
        {
            Debug.Log(ability.name + " activated!");

            foreach (AbilityUIEffect e in effects)
            {
                e.OnActivate();
            }
        }

        void OnCooldown()
        {
            Debug.Log(ability.name + " availible in " + ability.CooldownTime + " seconds");

            foreach (AbilityUIEffect e in effects)
            {
                e.OnCooldown();
            }
        }
    }
}