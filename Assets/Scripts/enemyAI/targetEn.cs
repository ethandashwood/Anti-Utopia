using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetEn : MonoBehaviour
{
    public float health = 100f;


    public void TakeDam(float amount)
    {
        health =- 10f;

        if (health <= 0f)
        {
            EnDeath();
        }
    }

    void EnDeath()
    {
        sceneAI.playerKills += 1;
        Destroy(gameObject);
    }
}
