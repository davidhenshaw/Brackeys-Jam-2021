using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using metakazz.Util;

namespace metakazz
{
    public class SceneController : MonoBehaviour
    {
        public static SceneController instance;

        float elapsed;
        [Header("Incoming Events")]
        public VoidEventSO loadMainMenuEvent;
        public VoidEventSO loadGameplayEvent;
        [Header("Outgoing Events")]
        public VoidEventSO quitAppEvent;
        public VoidEventSO quitAppCanceled;
        [SerializeField]
        public float quitTime = 3f;

        private void Awake()
        {
            SetUpSingleton();
        }

        private void SetUpSingleton()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            loadGameplayEvent.OnEventRaised += LoadGameplayScene;
            loadMainMenuEvent.OnEventRaised += LoadMainMenu;
        }

        // Update is called once per frame
        void Update()
        {
            RunQuitTimer();

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                quitAppEvent.RaiseEvent();
            }

            if(Input.GetKeyUp(KeyCode.Escape))
            {
                CancelQuit();
                quitAppCanceled.RaiseEvent();
                Debug.Log("Quit Cancelled");
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                LoadGameplayScene();
            }
        }

        public void LoadGameplayScene()
        {
            StartCoroutine(LoadGameplayScene_co());
        }

        public void LoadMainMenu()
        {
            StartCoroutine(LoadMainMenuScene_co());
        }

        IEnumerator LoadMainMenuScene_co()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main Menu");

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        IEnumerator LoadGameplayScene_co()
        {
            AsyncOperation asyncGameplayLoad = SceneManager.LoadSceneAsync("SampleScene");
            AsyncOperation asyncUILoad = SceneManager.LoadSceneAsync("Gameplay UI", LoadSceneMode.Additive);

            while (!asyncGameplayLoad.isDone && !asyncUILoad.isDone)
            {
                yield return null;
            }
        }

        void RunQuitTimer()
        {
            if ( !Input.GetKey(KeyCode.Escape) )
                return;

            elapsed += Time.deltaTime;

            if(elapsed >= quitTime)
            {
                Debug.Log("Quitting");
                Application.Quit();
                elapsed = 0;
            }
        }

        void CancelQuit()
        {
            elapsed = 0;
        }
    }
}