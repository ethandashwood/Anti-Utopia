 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneAI : MonoBehaviour
{

    public GameObject enemyPre;
    public GameObject player;

    public static int gPoints;
    public static int playerKills = 0;
    public static int pKills = 0;
    public static int roundC = 0;

    void Start()
    {
        SpawnEnemies();
        Respawnplay();
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

}
