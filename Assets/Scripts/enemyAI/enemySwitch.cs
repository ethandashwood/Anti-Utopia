using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemySwitch : MonoBehaviour
{
    private float timebshots;
    public float stimebshots;

    public NavMeshAgent enemy;
    public Transform Player;

    public GameObject playt;
    public GameObject proj;
    private float speed;
    public float enRange = 60;
    //public Transform ene;
    AudioSource eneGun;


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
        enemy = GetComponent<NavMeshAgent>();
        timebshots = sceneAI.enemyTimeBShots;
        eneGun = GetComponent<AudioSource>();

    }

    void Update()
    {

        CheckAttack();

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

        //if (speed == 0.0f)
       // {
           // enemyState = EnemyStates.Attack;
      //  }
    }

    void AttackState()
    {
        if (timebshots <= 0)
        {
            eneGun.Play();
            Instantiate(proj, new Vector3(0,0,0), Quaternion.identity);            
            timebshots = stimebshots;
        }
        else
        {
            timebshots -= Time.deltaTime;

        }
        //Debug.Log("Attacking player");
    }

    void CheckAttack()
    {

        if (targetEn.beingAttack!)
        {
            //Debug.Log("being attacked");
            enemyState = EnemyStates.Attack;
        }
        else
        {
            enemyState = EnemyStates.Chase;
        }

        /*RaycastHit hit;
        if (Physics.SphereCast(ene.transform.position, ene.transform.forward, out hit, enRange))
        {
            Debug.Log(hit.transform.name);
        }
        */
    }
    



}
