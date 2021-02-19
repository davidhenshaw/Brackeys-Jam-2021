using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace metakazz{
    public class UIController : MonoBehaviour
    {
        public VoidEventSO LoseEventSO;
        public VoidEventSO WinEventSO;

        public UnityEvent OnWin;
        public UnityEvent OnLose;

        private void Awake()
        {
            LoseEventSO.OnEventRaised += TriggerOnLose;
            WinEventSO.OnEventRaised += TriggerOnWin;
        }

        void TriggerOnLose()
        {
            OnLose?.Invoke();
        }

        void TriggerOnWin()
        {
            OnWin?.Invoke();
        }
    }
}