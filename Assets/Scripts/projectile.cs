using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public Transform playTar;

    public float bullSpeed;
    private Transform player;
    private Vector3 target;
    bool shot;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);

        shot = false;

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, bullSpeed * Time.deltaTime);

        if (transform.position.x == target.x || transform.position.y == target.y || transform.position.z == target.z)
        {
            Destroy();
        }

        if (shot = true)
        {
            shot = false;
            PlayerHealth.pHealth -= 100;
            Debug.Log(PlayerHealth.pHealth);
            Destroy();

        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shot = true;

        }
    }

    void Destroy()
    {
        Destroy(gameObject);
        Debug.Log("WEE");
    }
}