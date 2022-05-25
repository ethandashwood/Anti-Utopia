using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetEn : MonoBehaviour
{
    public float health = 100f;
    public static bool beingAttack = false;

    public Transform enemyPos;

    public GameObject blood;

    public Vector3 hitOffset;

    void Start()
    {
        beingAttack = false;
    }

    public void TakeDam()
    {
        beingAttack = true;
        health -= 300f;
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
    }
}
