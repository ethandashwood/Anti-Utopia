using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuUI : MonoBehaviour
{

    public GameObject how2play;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void How2playOn()
    {
        how2play.SetActive(true);
    }

    public void How2playOff()
    {
        how2play.SetActive(false);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);

    }
}
