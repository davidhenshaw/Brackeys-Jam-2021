using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace metakazz{
    [CreateAssetMenu(menuName = "HerdBehavior/Composite")]
    public class CompositeBehavior : HerdBehavior
    {
        public HerdBehavior[] behaviors;

        public override Vector2 CalculateMove(HerdAgent agent, List<Transform> context, Herd herd)
        {
            throw new System.NotImplementedException();
        }
    }

    [CustomEditor(typeof(CompositeBehavior))]
    public class CompositeBehaviorEditor : Editor
    {
        float weightSlider = 1;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CompositeBehavior behavior = (CompositeBehavior)target;

            GUILayout.BeginHorizontal();
            GUILayout.Label("Weight",GUILayout.ExpandWidth(false));

            GUILayout.Label(" " + weightSlider.ToString(), GUILayout.ExpandWidth(false));


            weightSlider = GUILayout.HorizontalSlider(weightSlider, 0, 1);
            GUILayout.EndHorizontal();

        }
    }
}