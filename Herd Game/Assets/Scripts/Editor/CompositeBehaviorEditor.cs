using UnityEngine;
using UnityEditor;

namespace metakazz
{
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

            EditorUtility.SetDirty(target);
        }
    }
}