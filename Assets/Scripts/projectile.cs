using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public GameObject playTar;

    public float bullSpeed;
    private Transform player;
    private Vector3 target;
    bool shot;

    public static float enDam = 10;
    
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playTar = GameObject.Find("playOB");

        shot = false;

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, bullSpeed * Time.deltaTime);
        target = new Vector3(player.position.x, player.position.y, player.position.z);

        if (transform.position.x == target.x || transform.position.y == target.y || transform.position.z == target.z)
        {
            Destroy();
        }

        if (shot = true)
        {
            shot = false;
            PlayerHealth.pHealth -= sceneAI.enemyDamage;
            Debug.Log(PlayerHealth.pHealth);
            Destroy();
        }


    }

    void OnCollisionEnter(Collision collision)
    {

        //if (collision.gameObject.tag == "player")
       // {
            //shot = true;
       // }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}