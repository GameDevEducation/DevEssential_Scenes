using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class Bootstrapper
{
    const string BootstrapSceneName = "Bootstrap Scene";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void PerformBootstrap()
    {
        // check if bootstrap scene is already loaded
        for(int sceneIndex = 0; sceneIndex < SceneManager.sceneCount; ++sceneIndex)
        {
            if (SceneManager.GetSceneAt(sceneIndex).name == BootstrapSceneName)
                return;
        }

        // load the bootstrap scene
        SceneManager.LoadScene(BootstrapSceneName, LoadSceneMode.Additive);
    }
}
