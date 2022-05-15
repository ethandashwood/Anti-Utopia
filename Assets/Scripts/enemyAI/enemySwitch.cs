using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemySwitch : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public GameObject playt;
    private float speed;


    enum EnemyStates
    {
        Idle,
        Chase,
        Attack
    }

    EnemyStates enemyState;

    void Start()
    {
        Player = GameObject.Find("player").transform;
        enemyState = EnemyStates.Chase;
    }

    void Update()
    {
        if (enemyState == EnemyStates.Idle)
        {
            IdleState();
        }

        if (enemyState == EnemyStates.Chase)
        {
            ChaseState();
        }

        if (enemyState == EnemyStates.Attack)
        {
            AttackState();
        }
    }

    void IdleState()
    {

    }

    void ChaseState()
    {
        enemy.SetDestination(Player.position);
    }

    void AttackState()
    {
        
    }
    



}
