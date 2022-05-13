using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySwitch : MonoBehaviour
{

    private float timeToChangeDirection;

    public GameObject tracker;

    enum EnemyStates
    {
        Idle,
        Chase,
        Attack
    }

    EnemyStates enemyState;

    void Start()
    {
        enemyState = EnemyStates.Idle;
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

        timeToChangeDirection -= Time.deltaTime;
 
        if (timeToChangeDirection <= 0) 
        {
            ChangeDirection();
        }
 
    }

    void ChaseState()
    {

    }

    void AttackState()
    {
        
    }
    

    private void ChangeDirection() 
    {
        float pSpeed = 10.0f;

        float angle1 = Random.Range(0f, 360f);
        float angle2 = Random.Range(0f, 360f);

        Vector3 moveAng = new Vector3(angle1, 0 , 0);
        transform.Translate (moveAng * pSpeed * Time.deltaTime);
        timeToChangeDirection = 1.5f;
    }

}
