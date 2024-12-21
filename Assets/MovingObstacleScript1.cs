using UnityEngine;

public class MovingObstacleScript : MonoBehaviour
{
    [SerializeField] private Transform m_startwaypoint1;
    [SerializeField] private Transform m_endwaypoint2;
    [SerializeField] private float m_speed = 5;

    private Transform m_target;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_target = m_startwaypoint1;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, m_target.position, m_speed * Time.deltaTime);
       
    }

    void ChangeTarget()
    {
        if (m_target != m_startwaypoint1)
        {
            m_target = m_startwaypoint1;
        }
        else
        {
            m_target = m_endwaypoint2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovvingObstacleWayPoint"))
        {
            ChangeTarget();
        }
        
    }
}
