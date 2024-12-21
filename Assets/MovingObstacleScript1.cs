using UnityEngine;

public class MovingObstacleScript : MonoBehaviour
{
    [SerializeField] private Transform m_startwaypoint;
    [SerializeField] private Transform m_endwaypoint;
    [SerializeField] private float m_speed = 5;

    private Transform m_target;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_target = m_startwaypoint;
    }

    // Update is called once per frame
    void Update()
    {
        float rotationangle = m_speed * Time.deltaTime;

        transform.RotateAround(m_target.position, Vector3.forward, rotationangle);
       
    }

    void ChangeTarget()
    {
        if (m_target != m_startwaypoint)
        {
            m_target = m_startwaypoint;
        }
        else
        {
            m_target = m_endwaypoint;
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
