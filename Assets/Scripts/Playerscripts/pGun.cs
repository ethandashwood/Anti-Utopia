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

    public GameObject light;

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
        light.SetActive(true);
        fireAnim.SetBool("isShot", true);
        yield return new WaitForSeconds(1/10);
        fireAnim.SetBool("isShot", false);
        light.SetActive(false);

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
                Debug.Log("hitting enemy");
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
