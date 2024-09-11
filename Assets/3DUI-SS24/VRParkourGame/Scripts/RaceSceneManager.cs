using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class RaceSceneManager : MonoBehaviour
    {
        public UnityEvent OnRaceSceneLoad;
        public UnityEvent OnRaceSceneUnLoad;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += SceneLoadeEventListener;
            SceneManager.sceneUnloaded += SceneUnLoadeEventListener;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= SceneLoadeEventListener;
            SceneManager.sceneUnloaded -= SceneUnLoadeEventListener;
        }

        private void SceneLoadeEventListener(Scene arg0, LoadSceneMode arg1)
        {
            CallSceneLoadeEventSubscribers();
        }

        private void SceneUnLoadeEventListener(Scene scene)
        {
            CallSceneLoadeEventSubscribers();
        }

        //void Start()
        //{
        //    callSceneLoadeEventSubscribers(); // assuming when first frame is rendered the scene is completely loaded
        //}

        //private void OnDestroy()
        //{
        //    callSceneUnLoadeEventSubscriber();// assuming is only destroyed when the scene is completely unloaded
        //}

        private void CallSceneLoadeEventSubscribers()
        {
            OnRaceSceneLoad?.Invoke();
        }

        private void CallSceneUnLoadeEventSubscribers()
        {
            OnRaceSceneUnLoad?.Invoke();
        }
    }
}