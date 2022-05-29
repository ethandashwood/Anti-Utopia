using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pGun : MonoBehaviour
{
    public ParticleSystem gunflash;
    public static float dam = 200f;
    public float range = 5000f;
    public Animator fireAnim;

    public float shotTime;
    private float shotTimer;

    AudioSource shotSound;

    public Camera pCam;

    void Start()
    {
        shotSound = GetComponent<AudioSource>();
        shotTimer = shotTime;

    }

    void Update()
    {
        fireAnim = GetComponent<Animator>();


        if (Input.GetButtonDown("Fire1") && shotTimer <= 0)
        {
            shotSound.Play();
            Shot();
            StartCoroutine(Shooting());
            shotTimer = shotTime;
        }
        else
        {
            shotTimer -= Time.deltaTime;
        }

    }


    IEnumerator Shooting()
    {
        fireAnim.SetBool("isShot", true);
        Debug.Log("bruh");
        yield return new WaitForSeconds(1/2);
        fireAnim.SetBool("isShot", false);
        Debug.Log("lol");
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
                target.TakeDam();
                sceneAI.gPoints += 20;
            }
            else
            {
                sceneAI.gPoints -= 5;
                gameTimer.timerGame -= 1;

            }
        }
    }
    
}
