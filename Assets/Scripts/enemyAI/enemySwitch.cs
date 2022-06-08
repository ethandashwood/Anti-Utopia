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
    public Transform enemyPos;
    public Animator enemyAnim;


    public GameObject gunLight;
    public GameObject enemyL;
    public GameObject proj;
    private float speed;
    public float enRange = 60;
    //public Transform ene;
    AudioSource eneGun;

    public LayerMask whatIsPlayer;

    public bool attackInRange;
    public float attackRange;

    bool attacking = false;

    public ParticleSystem gunflash;


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

        speed = 3;

        enemyAnim = GetComponent<Animator>();
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

        Vector3 targetDir = Player.position - transform.position;
        float stepSpeed = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSpeed, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void IdleState()
    {

    }

    void ChaseState()
    {
        enemy.SetDestination(Player.position);
        enemyAnim.Play("walking");
    }

    void AttackState()
    {


        if (timebshots <= 0)
        {
            Instantiate(proj, new Vector3(0,0,0), Quaternion.identity);            
            timebshots = stimebshots;
            eneGun.Play();
            StartCoroutine(Gunflash());
        }
        else
        {
            timebshots -= Time.deltaTime;
        }

    }

    IEnumerator Gunflash()
    {
        gunLight.SetActive(true);
        yield return new WaitForSeconds(1/2);
        gunLight.SetActive(false);
        yield return new WaitForSeconds(1/2);
        gunLight.SetActive(true);
        yield return new WaitForSeconds(1/2);
        gunLight.SetActive(false);

    }

    void CheckAttack()
    {


        if (attacking == true)
        {
            enemyState = EnemyStates.Attack;
        }
        
        if (attacking == false)
        {
            enemyState = EnemyStates.Chase;
        }


        attackInRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (attackInRange)
        {
            AttackState();

        }
        else
        {
            ChaseState();
        }
    }

}
