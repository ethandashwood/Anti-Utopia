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

        sEasScore = 800;
        easScore = 1000;
        midScore = 1100;
        hardScore = 1250;
        superHardScore = 1350;

        Medium();

    }

    void Update()
    {
        if (Input.GetKey("k"))
        {
            gPoints += 100;
        }

        if (Input.GetKey("m"))
        {
            gPoints -= 100;

        }

        if (pKills >= 9)
        {
            // AddPoints();
            SpawnEnemies();

            pKills = 0;

            roundC += 1;
            Debug.Log(roundC);
        }

        if (roundC == 2)
        {
            // AddPoints();
            Respawnplay();
            pKills = 0;
            roundC = 0;
            PlayerHealth.pHealth += addedHealth;
            if (PlayerHealth.pHealth > 1000)
            {
                PlayerHealth.pHealth = 1000;
            }

            gameTimer.timerGame = 20;

            projectile.enDam += 2;

            addCompScore();
            CheckDifficulty();
        }

        if(PlayerHealth.pHealth < 0 && dead == true)
        {
            //Time.timeScale = 0f;
            reset.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            dead = false;
        }

        if (gameTimer.timerGame < 0)
        {
            reset.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            dead = false;
        }


    }

    void Respawnplay()
    {
        player.transform.position = new Vector3(-135, 4, 17);
    }

    void addCompScore()
    {
        sEasScore += 800;
        easScore += 1000;
        midScore += 1100;
        hardScore += 1250;
        superHardScore += 1350;
    }


    /*void AddPoints()
    {
        gPoints += pGun.points;
    }
    */

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
        enemyDamage = 5f;
        enemyTimeBShots = 4f;

        disDiff = ("Super Easy");
    }

    void Easy()
    {
        addedHealth = 900f;
        playerDamage = 450f;
        enemyDamage = 8f;
        enemyTimeBShots = 3.3f;

        disDiff = ("Easy");
    }

    void Medium()
    {
        addedHealth = 800f;
        playerDamage = 400f;
        enemyDamage = 10f;
        enemyTimeBShots = 3f;

        disDiff = ("Average");
    }

    void Skilled()
    {
        addedHealth = 600f;
        playerDamage = 250f;
        enemyDamage = 15f;
        enemyTimeBShots = 2f;

        disDiff = ("Skilled");
    }

    void SuperSkilled()
    {
        addedHealth = 500f;
        playerDamage = 180f;
        enemyDamage = 17f;
        enemyTimeBShots = 1.7f;

        disDiff = ("Super Skilled");
    }

}
