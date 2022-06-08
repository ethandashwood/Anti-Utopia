using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetEn : MonoBehaviour
{
    public float health = 100f;
    public static bool beingAttack = false;

    public Transform enemyPos;

    public GameObject blood;
    //private GameObject self;

    public Vector3 hitOffset;
    public Transform enemyTar;

    void Start()
    {
        beingAttack = false;
    }

    void Update()
    {
        //transform.position = enemyTar.position;
        //transform.rotation = enemyTar.rotation;

    }

    public void TakeDam()
    {
        beingAttack = true;
        health -= sceneAI.playerDamage;
        Debug.Log(health);
        Instantiate(blood, enemyPos.position + hitOffset, Quaternion.identity);

        if (health < 0f)
        {
            beingAttack = false;
            EnDeath();
        }
    }

    void EnDeath()
    {
        sceneAI.pKills += 1;
        sceneAI.playerKills += 1;
        Destroy(gameObject);
        gameTimer.timerGame += 5;
    }
}
