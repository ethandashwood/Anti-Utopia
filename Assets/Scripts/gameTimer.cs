using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameTimer : MonoBehaviour
{
    public static float timerGame;

    void Start()
    {
        timerGame = 20;
    }

    void Update()
    {

        if (timerGame > 0)
        {
            timerGame -= Time.deltaTime;
        }
        else
        {
            Debug.Log("timer has ran out");
        }
    }
}
