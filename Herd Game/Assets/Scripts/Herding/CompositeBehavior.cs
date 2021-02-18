using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace metakazz{
    [CreateAssetMenu(menuName = "HerdBehavior/Composite")]
    public class CompositeBehavior : HerdBehavior
    {
        public HerdBehavior[] behaviors;
        [HideInInspector]
        public float[] weights;

        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            Vector2 movement = Vector2.zero;

            for(int i = 0; i < behaviors.Length; i++)
            {
                Vector2 weightedMove = behaviors[i].CalculateMove(agent, context, herd) * weights[i];

                movement += weightedMove;
            }

            return movement;
        }

        public override void Initialize()
        {
            foreach(HerdBehavior hb in behaviors)
            {
                hb.Initialize();
            }
        }
    }

    [CustomEditor(typeof(CompositeBehavior))]
    public class CompositeBehaviorEditor : Editor
    {
        float[] weights;
        float minSliderValue = 0;
        float maxSliderValue = 5;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CompositeBehavior behavior = (CompositeBehavior)target;

            if (behavior == null)
                return;

            if (behavior.behaviors == null || behavior.behaviors.Length == 0)
                return;

            int behaviorCount = behavior.behaviors.Length;
            weights = behavior.weights;

            //Generate weight sliders based on number of behaviors
            if(weights == null || behaviorCount != weights.Length)
                weights = new float[behaviorCount];

            GUILayout.BeginVertical();
            for(int i = 0; i < weights.Length; i++)
            {
                string labelName = "";
                if (behavior.behaviors[i] != null)
                    labelName = behavior.behaviors[i].name;

                weights[i] = EditorGUILayout.Slider(labelName + $"({i})", weights[i], minSliderValue, maxSliderValue);
            }
            GUILayout.EndVertical();

            behavior.weights = this.weights;
        }
    }
}