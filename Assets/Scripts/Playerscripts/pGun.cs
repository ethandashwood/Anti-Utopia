using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pGun : MonoBehaviour
{
    public ParticleSystem gunflash;
    public float dam = 30f;
    public float range = 5000f;

    public Camera pCam;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            Shot();
        }
    }

    void Shot()
    {
        gunflash.Play();
        RaycastHit hit;
        if (Physics.Raycast(pCam.transform.position, pCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            targetEn target = hit.transform.GetComponent<targetEn>();
            if (target != null)
            {
                target.TakeDam(dam);
            }
        }
    }
    
}