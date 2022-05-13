using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneAI : MonoBehaviour
{

    public GameObject enemyPre;
    public GameObject player;

    public static int gPoints;
    public static int playerKills = 0;

    void Start()
    {
        SpawnEnemies();
    }

    void Update()
    {


        if (playerKills >= 7)
        {
            AddPoints();
            SpawnEnemies();

            playerKills = 0;
        }

    }



    void AddPoints()
    {
        gPoints += pGun.points;
    }

    void SpawnEnemies()
    {

        player.transform.position = new Vector3(-135, 4 ,17);

        Instantiate(enemyPre, new Vector3(47, 2, 104), Quaternion.identity);
        Instantiate(enemyPre, new Vector3(64, 2, -28), Quaternion.identity);
        Instantiate(enemyPre, new Vector3(-75, 2, -78), Quaternion.identity);
        Instantiate(enemyPre, new Vector3(-1, 2, -75), Quaternion.identity);
        Instantiate(enemyPre, new Vector3(64, 2, -81), Quaternion.identity);
        Instantiate(enemyPre, new Vector3(-111, 2, 21), Quaternion.identity);
        Instantiate(enemyPre, new Vector3(-74, 2, -16), Quaternion.identity);



    }

}
