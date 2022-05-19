using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(1);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);        
    }

    public void QuitGame()
    {

        Application.Quit();
    }

}
