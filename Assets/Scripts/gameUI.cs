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
    [SerializeField]
    private Text timer;
    [SerializeField]
    private Text difficulty;
    [SerializeField]
    private Text roundCount;

    public GameObject escapeO;



    void Start()
    {
        gameScore.text = "Game Score: " + 0;
        playKills.text = "Kills: " + 0;
        playHealth.text = "Health: " + 0;
        timer.text = "Time Left: " + 0;
        difficulty.text = "difficulty: ";
        //roundCount.text;
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
        gameScore.text = "Points " + sceneAI.gPoints.ToString();
        playHealth.text = (PlayerHealth.pHealth / 10).ToString() + "%";
        difficulty.text = "Difficulty " + sceneAI.disDiff;
        timer.text = "TIME: " + (Mathf.Round(gameTimer.timerGame)).ToString();

        roundCount.text = sceneAI.rounds.ToString();


    }
}
