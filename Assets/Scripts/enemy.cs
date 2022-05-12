using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{

    private NavMeshAgent enemy;

    public GameObject Player;

    public float MobDistRun = 4.0f;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if(distance < MobDistRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            enemy.SetDestination(newPos);
        }
    }
}
