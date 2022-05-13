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

    void Start()
    {
        gameScore.text = "Game Score: " + 0;
        playKills.text = "Kills: " + 0;
    }

    void Update()
    {
        updateScore();
    }

    public void updateScore()
    {

        playKills.text = sceneAI.playerKills.ToString();
        gameScore.text = pGun.points.ToString();

    }
}
