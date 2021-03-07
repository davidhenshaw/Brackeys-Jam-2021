using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metakazz.Util;
using System;

namespace metakazz{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private void SetUpSingleton()
        {
            if (instance == null)
            {
                instance = this;
                //DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public event Action<Difficulty> DifficultyChanged;

        public TransformAnchor mainHerdAnchor;
        Herd mainHerd;

        public int scoreToLose = 5;
        [HideInInspector] public int scoreToWin = 8;

        int _currScore;
        int _numTramples;

        /*Events*/
        [Header("Events")]
        public VoidEventSO LoseEvent;
        public VoidEventSO WinEvent;
        public IntEventSO AgentEnteredGoalArea;
        public IntEventSO AgentExitedGoalArea;

        [Header("Anchors")]
        public FloatAnchor mainHerdSizeAnchor;
        public FloatAnchor trampleCountAnchor;

        [Space]
        [Header("Music")]
        public AudioCueSO gameplayMusicCue;
        public AudioCueSO gameOverMusicCue;

        private void Awake()
        {
            SetUpSingleton();
        }

        // Start is called before the first frame update
        void Start()
        {
            if(mainHerdAnchor.Transform)
                mainHerd = mainHerdAnchor.Transform.GetComponent<Herd>();

            if (mainHerd)
            {
                mainHerd.AgentAdded += OnHerdAgentGained;
                mainHerd.AgentRemoved += OnHerdAgentLost;
            }

            //AgentEnteredGoalArea.OnEventRaised += CheckForWin;

            AgentEnteredGoalArea.OnEventRaised += UpdateScore;
            AgentExitedGoalArea.OnEventRaised += UpdateScore;

            mainHerdSizeAnchor.Value = mainHerd.AgentCount;
            trampleCountAnchor.Value = 0;

            Prey.PredatorTrampled += OnPredatorTrampled;

            gameplayMusicCue.RaiseEvent();
        }

        void OnHerdAgentGained(HerdAgent a)
        {
            if (mainHerdSizeAnchor != null)
                mainHerdSizeAnchor.Value = mainHerd.AgentCount;
        }

        void OnHerdAgentLost(HerdAgent a)
        {
            if(mainHerdSizeAnchor != null)
                mainHerdSizeAnchor.Value = mainHerd.AgentCount;

            CheckForLose(mainHerd.AgentCount);
        }

        void OnPredatorTrampled(Transform t)
        {
            _numTramples++;

            if(trampleCountAnchor != null)
                trampleCountAnchor.Value = _numTramples;
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
            {
                LoseEvent?.RaiseEvent();
                gameOverMusicCue?.RaiseEvent();
            }

        }
    }

    public enum Difficulty
    {
        Easy, Normal, Hard, Insane
    }
}