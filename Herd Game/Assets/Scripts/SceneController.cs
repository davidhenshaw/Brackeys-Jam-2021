using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace metakazz{
    public class SceneController : MonoBehaviour
    {
        public static SceneController instance;

        [SerializeField]
        public float quitTime = 3f;
        float elapsed;

        public VoidEventSO quitAppEvent;
        public VoidEventSO quitAppCanceled;

        private void Awake()
        {
            SetUpSingleton();
            SceneManager.LoadSceneAsync("Gameplay UI", LoadSceneMode.Additive);
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
                StartCoroutine(ReloadScene());
            }
        }

        IEnumerator ReloadScene()
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