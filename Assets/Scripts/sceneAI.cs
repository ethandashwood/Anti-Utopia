 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sceneAI : MonoBehaviour
{

    public GameObject enemyPre;
    public GameObject player;
    public GameObject reset;

    public static int gPoints;
    public static int playerKills = 0;
    public static int pKills = 0;
    public static int roundC = 0;
    public static int rounds = 1;
    public static int timeAdd = 0;

    public static bool dead = false;


    //difficulty Vars

    public static float addedHealth;
    public static float playerDamage;
    public static float enemyDamage;
    public static float enemyTimeBShots;

    public static int sEasScore = 0;
    public static int easScore = 0;
    public static int midScore = 0;
    public static int hardScore = 0;
    public static int superHardScore = 0;

    public static string disDiff;

    void Start()
    {
        rounds = 1;
        gPoints = 0;
        playerKills = 0;
        pKills = 0;
        roundC = 0;
        SpawnEnemies();
        Respawnplay();
        Time.timeScale = 1f;

        sEasScore = 0;
        easScore = 0;
        midScore = 0;
        hardScore = 0;
        superHardScore = 0;

        Medium();

    }

    void Update()
    {
        timeAdd = Mathf.RoundToInt(gameTimer.timerGame);

        if (pKills >= 9)
        {
            SpawnEnemies();

            pKills = 0;

            roundC += 1;
            Debug.Log(roundC);
        }

        if (roundC == 2)
        {
            pKills = 0;
            roundC = 0;

            Respawnplay();
            HealthReset();
            addCompScore();
            CheckDifficulty();
            TimerReset();

            gPoints += timeAdd;
            projectile.enDam += 2;
            rounds += 1;
        }

        CheckHealthDeath();
        CheckTimeDeath();

    }



    // Checks if health is zero
    void CheckHealthDeath()
    {
        if (PlayerHealth.pHealth < 0 && dead == true)
        {
            reset.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            dead = false;
        }
    }

    //Checks if timer is zero
    void CheckTimeDeath()
    {
        if (gameTimer.timerGame < 0)
        {
            reset.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;

            dead = false;
        }
    }

    // Resets / Adds player's Health
    void HealthReset()
    {
        PlayerHealth.pHealth += addedHealth;
        if (PlayerHealth.pHealth > 1000)
        {
            PlayerHealth.pHealth = 1000;
        }
    }

    // Resets Player position
    void Respawnplay()
    {
        player.transform.position = new Vector3(-135, 4, 17);
    }

    // Adds comparison score for next round
    void addCompScore()
    {
        sEasScore += 700;
        easScore += 900;
        midScore += 1000;
        hardScore += 1300;
        superHardScore += 1500;
    }

    // Resets Timer
    void TimerReset()
    {
        gameTimer.timerGame = 20;
    }

    // Respawns enemies
    void SpawnEnemies()
    {

       Instantiate(enemyPre, new Vector3(139, 2, 52), Quaternion.identity);
       Instantiate(enemyPre, new Vector3(110, 2, 137), Quaternion.identity);
       Instantiate(enemyPre, new Vector3(86, 2, -114), Quaternion.identity);
       Instantiate(enemyPre, new Vector3(-107, 2, 88), Quaternion.identity);
       Instantiate(enemyPre, new Vector3(-44, 2, 88), Quaternion.identity);
       Instantiate(enemyPre, new Vector3(-113, 2, -35), Quaternion.identity);
       Instantiate(enemyPre, new Vector3(-47, 2, -104), Quaternion.identity);
       Instantiate(enemyPre, new Vector3(85, 2, 159), Quaternion.identity);
       Instantiate(enemyPre, new Vector3(52, 2, 167), Quaternion.identity);

    }

    //checks the player's difficulty
    void CheckDifficulty()
    {
        if (gPoints > sEasScore)
        {
            SuperEase();
        }

        if (gPoints > easScore)
        {
            Easy();
        }

        if (gPoints > midScore)
        {
            Medium();
        }

        if (gPoints > hardScore)
        {
            Skilled();
        }

        if (gPoints > superHardScore)
        {
            SuperSkilled();
        }
    }

    // Player Difficulty levels and variables
    void SuperEase()
    {
        addedHealth = 1100f;
        playerDamage = 500f;
        enemyDamage = 35f;
        enemyTimeBShots = 3f;

        disDiff = ("Super Easy");
    }

    void Easy()
    {
        addedHealth = 900f;
        playerDamage = 333.3f;
        enemyDamage = 45f;
        enemyTimeBShots = 2.8f;

        disDiff = ("Easy");
    }

    void Medium()
    {
        addedHealth = 800f;
        playerDamage = 260f;
        enemyDamage = 60f;
        enemyTimeBShots = 2.2f;

        disDiff = ("Average");
    }

    void Skilled()
    {
        addedHealth = 600f;
        playerDamage = 230f;
        enemyDamage = 90f;
        enemyTimeBShots = 2f;

        disDiff = ("Skilled");
    }

    void SuperSkilled()
    {
        addedHealth = 500f;
        playerDamage = 200f;
        enemyDamage = 100f;
        enemyTimeBShots = 2f;

        disDiff = ("Super Skilled");
    }

}
