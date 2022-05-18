using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetEn : MonoBehaviour
{
    public float health = 100f;


    public void TakeDam()
    {
        health -= 300f;
        Debug.Log(health);
        Debug.Log("ouch");

        if (health < 0f)
        {
            EnDeath();
            Debug.Log("Dead");
        }
    }

    void EnDeath()
    {
        sceneAI.pKills += 1;
        sceneAI.playerKills += 1;
        Destroy(gameObject);
    }
}
