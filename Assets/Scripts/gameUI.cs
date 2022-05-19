using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameUI : MonoBehaviour
{
    [SerializeField]
    private Text gameScore;
    [SerializeField]
    private Text playKills;
    [SerializeField]
    private Text playHealth;

    public GameObject escapeO;


    void Start()
    {
        gameScore.text = "Game Score: " + 0;
        playKills.text = "Kills: " + 0;
        playHealth.text = "Health: " + 0;

    }

    void Update()
    {
        updateScore();


        if (Input.GetKey(KeyCode.Escape))
        {
            OnEscape();
        }


    }

    public void OnEscape()
    {
        escapeO.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void BackEsc()
    {
        escapeO.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void updateScore()
    {

        playKills.text = "Kills " + sceneAI.playerKills.ToString();
        gameScore.text = "Points " + pGun.points.ToString();
        playHealth.text = "Health " + PlayerHealth.pHealth.ToString();

    }
}
