using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace metakazz{
    public class UIController : MonoBehaviour
    {
        public VoidEventSO LoseEventSO;

        public UnityEvent OnLose;

        private void Awake()
        {
            LoseEventSO.OnEventRaised += TriggerOnLose;
        }

        void TriggerOnLose()
        {
            OnLose?.Invoke();
        }
    }
}