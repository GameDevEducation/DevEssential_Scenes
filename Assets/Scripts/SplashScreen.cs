using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] Slider ProgressBar;
    [SerializeField] float LoadTimeBuffer = 5f;
    float LoadTimeBufferRemaining;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMainMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadMainMenu()
    {
        // start an async load of the main menu
        var sceneLoadOp = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);

        // set the remaining buffer time
        LoadTimeBufferRemaining = LoadTimeBuffer;

        // block automatic activation of the scene
        sceneLoadOp.allowSceneActivation = false;

        while(!sceneLoadOp.isDone)
        {
            // set the progress (will cap at 0.9)
            ProgressBar.value = sceneLoadOp.progress;

            // finished loading?
            if (sceneLoadOp.progress >= 0.9f)
            {
                LoadTimeBufferRemaining -= Time.deltaTime;

                // buffer time run out - finish loading
                if (LoadTimeBufferRemaining <= 0f)
                    sceneLoadOp.allowSceneActivation = true;
                else
                {
                    // get a 0 to 1 value of the buffer progress (0 = at start of buffer, 1 = end of buffer)
                    float bufferProgress = 1f - (LoadTimeBufferRemaining / LoadTimeBuffer);
                    ProgressBar.value = 0.9f + 0.1f * bufferProgress;
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
