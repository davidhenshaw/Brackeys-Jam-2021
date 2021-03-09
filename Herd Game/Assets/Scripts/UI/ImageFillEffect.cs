using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace metakazz
{
    //[RequireComponent(typeof(AbilityUIController))]

    public class ImageFillEffect : AbilityUIEffect
    {
        [Space]
        [SerializeField] Image image;

        public override void OnActivate()
        {
            StartCoroutine(
                DrainImage_co(ability.Duration)
                );
        }

        public override void OnCooldown()
        {
            StartCoroutine(
                FillImage_co(ability.CooldownTime)
                );
        }

        public override void OnReady()
        {
            //throw new System.NotImplementedException();
        }

        IEnumerator DrainImage_co(float totalTime)
        {
            float timeLeft = totalTime;
            while(image.fillAmount > 0)
            {
                var amount = Mathf.InverseLerp(0, totalTime, timeLeft);
                image.fillAmount = amount;
                timeLeft -= Time.deltaTime;
                yield return null;
            }
        }

        IEnumerator FillImage_co(float totalTime)
        {
            float elapsed = 0;
            while (image.fillAmount < 1)
            {
                var amount = Mathf.InverseLerp(0, totalTime, elapsed);
                image.fillAmount = amount;
                elapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}