using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace metakazz
{
    public class OverlayFlashEffect : AbilityUIEffect
    {
        [SerializeField] Image image;
        
        public Color flashColor;
        public float flashTime;
        [Space]
        public Color darkenColor;
        public float darkenTime;

        public override void OnActivate()
        {
            StartCoroutine(FlashColor_co());
        }

        public override void OnCooldown()
        {
            //throw new System.NotImplementedException();
        }

        public override void OnReady()
        {
            StartCoroutine(RestoreClear_co());
        }

        IEnumerator FlashColor_co()
        {
            float elapsed = 0;
            Color fromColor = Color.clear;

            while(elapsed < flashTime)
            {
                float amount = Mathf.InverseLerp(0, flashTime, elapsed);
                image.color = Color.Lerp(fromColor, flashColor, amount);
                elapsed += Time.deltaTime;
                yield return null;
            }

            elapsed = 0;
            fromColor = flashColor;

            while(elapsed < darkenTime)
            {
                float amount = Mathf.InverseLerp(0, darkenTime, elapsed);
                image.color = Color.Lerp(fromColor, darkenColor, amount);
                elapsed += Time.deltaTime;
                yield return null;
            }
        }

        IEnumerator RestoreClear_co()
        {
            float elapsed = 0;
            Color fromColor = image.color;

            while (elapsed < flashTime)
            {
                float amount = Mathf.InverseLerp(0, flashTime, elapsed);
                image.color = Color.Lerp(fromColor, Color.clear, amount);
                elapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}