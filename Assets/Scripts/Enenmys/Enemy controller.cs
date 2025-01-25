using System.Collections;
using System.Xml.Serialization;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;

public class Enemycontroller : MonoBehaviour
{

    protected Transform m_player;
    protected float M_speed;
    protected float m_stoppingDistance;
    protected bool m_PlayerInSight;
    protected bool m_Stunned;

    protected bool bCanAttack = true;

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
        M_speed = 10;
        m_stoppingDistance = 5;
      
        m_player = FindObjectOfType<TopDownCharacterController>().transform;
        m_State = EnemyStates.MoveToPlayer;
        ChangeState();

    }

    // Update is called once per frame
    void Update()
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

    void ChangeState()
    {
        

    }





    private void FixedUpdate()
    {
        
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.CompareTag("Player"))
        {
            m_State = EnemyStates.Attack;
            m_PlayerInSight = true;
            ChangeState();


        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_PlayerInSight = false;


        }


    }

 

    void HandleStateAttack()
    {
        if(bCanAttack)
        {
            Attack();
            Debug.Log("Attacked");
            bCanAttack = false;
            StartCoroutine(AttackDelay());
        }
        
    }

    void HandleStateWalkToPlayer()
    {
        if (Vector2.Distance(transform.position, m_player.position) > m_stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_player.position, M_speed * Time.deltaTime);

        }
    }




    public virtual void Attack()
    {


    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(AtkDelay);
        

        if (m_PlayerInSight == true)
        {
            HandleStateAttack();
            bCanAttack = true;

        }
        else
        {
            m_State = EnemyStates.MoveToPlayer;
            ChangeState();
            bCanAttack = true;
        }
        
    }

}
