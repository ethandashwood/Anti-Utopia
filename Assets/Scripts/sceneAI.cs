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

    public static bool dead = false;


    //difficulty Vars

    public static float addedHealth;
    public static float playerDamage;
    public static float enemyDamage;
    public static float enemyTimeBShots;

    public static int compareScore;


    void Start()
    {
        gPoints = 0;
        playerKills = 0;
        pKills = 0;
        roundC = 0;
        SpawnEnemies();
        Respawnplay();
        Time.timeScale = 1f;
    }

    void Update()
    {


        if (pKills >= 9)
        {
            AddPoints();
            SpawnEnemies();

            pKills = 0;

            roundC += 1;
            Debug.Log(roundC);
        }

        if (roundC == 2)
        {
            AddPoints();
           // SpawnEnemies();
            Respawnplay();
            pKills = 0;
            roundC = 0;
            PlayerHealth.pHealth += 500;
        }

        if(PlayerHealth.pHealth < 0 && dead == true)
        {
            //Time.timeScale = 0f;
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



    void AddPoints()
    {
        gPoints += pGun.points;
    }


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


    }

    // Player Difficulty levels and variables

    void SuperEase()
    {
        addedHealth = 1100f;
        playerDamage = 500f;
        enemyDamage = 5f;
        enemyTimeBShots = 4f;
    }

    void Easy()
    {
        addedHealth = 900f;
        playerDamage = 450f;
        enemyDamage = 8f;
        enemyTimeBShots = 3.3f;

    }

    void Medium()
    {
        addedHealth = 800f;
        playerDamage = 400f;
        enemyDamage = 10f;
        enemyTimeBShots = 3f;

    }

    void Skilled()
    {
        addedHealth = 600f;
        playerDamage = 250f;
        enemyDamage = 15f;
        enemyTimeBShots = 2f;

    }

    void SuperSkilled()
    {
        addedHealth = 500f;
        playerDamage = 180f;
        enemyDamage = 17f;
        enemyTimeBShots = 1.7f;

    }

}
