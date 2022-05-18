using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float pHealth;

    void Start()
    {
        pHealth = 1000;
    }

    void Update()
    {
        if (pHealth < 0)
        {
            Debug.Log("player dead");
        }
    }
}
