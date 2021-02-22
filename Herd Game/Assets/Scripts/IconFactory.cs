using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace metakazz
{
    public class IconFactory : MonoBehaviour
    {
        public static IconFactory instance;

        public ParentConstraint iconPrefab;

        private void Awake()
        {
            SetUpSingleton();
        }

        void SetUpSingleton()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void GenerateIcon(Transform parent, Sprite icon)
        {
            ParentConstraint newConstraint = Instantiate(iconPrefab, this.transform);
            SpriteRenderer spriteRenderer = newConstraint.GetComponent<SpriteRenderer>();

            spriteRenderer.sprite = icon;

            ConstraintSource source = new ConstraintSource();
            source.sourceTransform = parent;
            source.weight = 1;

            newConstraint.AddSource(source);
        }
    }
}