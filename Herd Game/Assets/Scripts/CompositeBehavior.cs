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
    }

    [CustomEditor(typeof(CompositeBehavior))]
    public class CompositeBehaviorEditor : Editor
    {
        float[] weights;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CompositeBehavior behavior = (CompositeBehavior)target;
            int behaviorCount = behavior.behaviors.Length;
            weights = behavior.weights;

            //Generate weight sliders based on number of behaviors
            if(weights == null || behaviorCount != weights.Length)
                weights = new float[behaviorCount];

            GUILayout.BeginVertical();
            for(int i = 0; i < weights.Length; i++)
            {
                weights[i] = EditorGUILayout.Slider(behavior.behaviors[i].name + $"({i})", weights[i], 0, 1);
            }
            GUILayout.EndVertical();

            behavior.weights = this.weights;
        }
    }
}