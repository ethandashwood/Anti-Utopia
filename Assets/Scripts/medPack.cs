using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medPack : MonoBehaviour
{

    public int medPackCount;
    public bool medUsed;

    void Start()
    {
        medPackCount = 1;
        medUsed = false;
    }

    void Update()
    {


        if (medUsed = false && medPackCount > 0)
        {
            if (Input.GetKey("q"))
            {
                PlayerHealth.pHealth += 100;

            }
            medUsed = true;

        }
        else
        {
            medUsed = false;
        }
    }

}
