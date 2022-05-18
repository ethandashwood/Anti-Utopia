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

    void Start()
    {
        gameScore.text = "Game Score: " + 0;
        playKills.text = "Kills: " + 0;
        playHealth.text = "Health: " + 0;

    }

    void Update()
    {
        updateScore();

    }

    public void updateScore()
    {

        playKills.text = "Kills " + sceneAI.playerKills.ToString();
        gameScore.text = "Points " + pGun.points.ToString();
        playHealth.text = "Health " + PlayerHealth.pHealth.ToString();

    }
}
