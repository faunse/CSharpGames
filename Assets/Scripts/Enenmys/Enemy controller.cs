using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemycontroller : MonoBehaviour
{

    protected Transform mc_player;
    protected float M_speed;
    protected float m_stoppingDistance;
    protected bool m_PlayerInSight;
    protected bool m_Stunned;
    public float m_maxSpeed;
    public float m_Damage;
    protected bool bCanAttack = true;
    private NavMeshAgent m_nav;

    protected float AtkDelay = 2.0f;
    
    enum EnemyStates
    {
        Idle,
        MoveToPlayer,
        Attack
    };
    EnemyStates m_State;    
    Vector2 m_direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        M_speed = m_maxSpeed;
        m_stoppingDistance = .75f;
        mc_player = FindObjectOfType<TopDownCharacterController>().transform;
        m_State = EnemyStates.MoveToPlayer;
        m_nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
     protected virtual void Update()
    {
        switch (m_State)
        {
            case EnemyStates.Idle:
                Debug.Log("Idle");
                break;
            case EnemyStates.MoveToPlayer:
                HandleStateWalkToPlayer();
                break;
            case EnemyStates.Attack:
                HandleStateAttack();
                break;
        }
    }
    
    private void FixedUpdate()
    {    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.CompareTag("Player"))
        {
            //*m_PlayerInSight = true;
            m_State = EnemyStates.Attack;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //*m_PlayerInSight = false;
            m_State = EnemyStates.MoveToPlayer;
        }
    }
    void HandleStateAttack()
    {
        if(bCanAttack)
        {
            Attack();
            M_speed = 0;
            m_nav.isStopped = true;
            bCanAttack = false;
            StartCoroutine(AttackDelay());
        }
    }
    void HandleStateWalkToPlayer()
    {
        m_nav.isStopped = false;
        M_speed = m_maxSpeed;
        m_nav.SetDestination(mc_player.position);
    }

    public virtual void Attack()
    {
    }

    public virtual void AddDificulty(int DMGplus, int Health)
    {
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(AtkDelay);
        bCanAttack = true;
    }

}
