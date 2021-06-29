using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoadLevel1()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void OnLoadLevel2()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
