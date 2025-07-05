using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Develop.Runtime.Utilities.SceneManagement
{
    public class SceneLoaderService
    {
        public IEnumerator LoadAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            AsyncOperation wait = SceneManager.LoadSceneAsync(sceneName, mode);
            
            yield return new WaitWhile(() => wait.isDone == false);
        }
        
        public IEnumerator UnloadAsync(string sceneName)
        {
            AsyncOperation wait = SceneManager.UnloadSceneAsync(sceneName);
            
            yield return new WaitWhile(() => wait.isDone == false);
        }
    }
}