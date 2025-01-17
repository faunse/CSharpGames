using UnityEditor;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{

    public Transform m_player;
    public float M_speed;
    public float m_stoppingDistance;
    bool m_PlayerInSight;
    public bool m_Stunned;
    enum EnemyStates
    {
        Idle,
        MoveToPlayer,
        Attack
    }
    Vector2 m_direction;


    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        m_player = FindObjectOfType<TopDownCharacterController>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, m_player.position) > m_stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_player.position, M_speed * Time.deltaTime);
        }

        if (m_)

        m_direction = m_player.position - transform.position;



        Debug.Log(m_direction.normalized);


    }

    private void FixedUpdate()
    {
        
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider other)
    {

        
    }

}
