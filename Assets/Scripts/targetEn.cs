using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetEn : MonoBehaviour
{
    public float health = 100f;

    public void TakeDam(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            EnDeath();
        }
    }

    void EnDeath()
    {
        Destroy(gameObject);
    }
}
