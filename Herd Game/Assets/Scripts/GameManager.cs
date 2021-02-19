using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;

namespace metakazz{
    public class GameManager : MonoBehaviour
    {
        public TransformAnchor mainHerdAnchor;
        Herd mainHerd;

        public int scoreToLose = 5;
        public int scoreToWin = 8;

        int _currScore;

        /*Events*/
        public VoidEventSO LoseEvent;
        public VoidEventSO WinEvent;
        [Space]
        public IntEventSO AgentEnteredGoalArea;
        public IntEventSO AgentExitedGoalArea;

        // Start is called before the first frame update
        void Start()
        {
            mainHerd = mainHerdAnchor.Transform.GetComponent<Herd>();
            mainHerd.AgentRemoved += OnHerdAgentLost;

            AgentEnteredGoalArea.OnEventRaised += CheckForWin;

            AgentEnteredGoalArea.OnEventRaised += UpdateScore;
            AgentExitedGoalArea.OnEventRaised += UpdateScore;
        }

        void OnHerdAgentLost(HerdAgent a)
        {
            CheckForLose(mainHerd.AgentCount);
        }

        void UpdateScore(int areaCount)
        {
            _currScore = areaCount;
        }

        void CheckForWin(int score)
        {
            if(score >= scoreToWin)
            {
                WinEvent.RaiseEvent();
            }
        }

        void CheckForLose(int herdCount)
        {
            if(herdCount < scoreToLose)
                LoseEvent.RaiseEvent();
        }
    }
}