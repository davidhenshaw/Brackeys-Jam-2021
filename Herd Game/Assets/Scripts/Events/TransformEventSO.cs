using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace metakazz{
    [CreateAssetMenu(menuName = "Events/Transform Event Channel")]
    public class TransformEventSO : ScriptableObject
    {
        public UnityAction<Transform> OnEventRaised;

        public void RaiseEvent(Transform value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}