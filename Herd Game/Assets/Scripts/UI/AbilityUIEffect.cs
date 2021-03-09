using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace metakazz
{
    public abstract class AbilityUIEffect : MonoBehaviour
    {
        public Ability ability;
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

        public abstract void OnReady();

        public abstract void OnActivate();

        public abstract void OnCooldown();
    }
}