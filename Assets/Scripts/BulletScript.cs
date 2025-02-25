using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    public float m_Dmg;
    public bool FireT;
    public bool Explosive;
    private bool m_Once;
    public GameObject m_explosion;
    private ParticleSystem m_particleSystem;

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    public void BulletStats(float m_dmg, bool A, bool B)
    {
        m_Dmg = m_dmg;
        FireT = A;
        Explosive = B;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Explosive)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 4);
            foreach (Collider2D Enemy in colliders)
            {
                GameObject Enemys = Enemy.gameObject;
                if (Enemys.GetComponent<EnemyHealthScript>() != null)
                {
                    
                    Enemys.GetComponent<EnemyHealthScript>().takeDMG(m_Dmg + 50, false);
                }
            }
            if (!collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }

        }

        else
        {
            if (collision.gameObject.CompareTag("Enemy") && !m_Once)
            {
                m_Once = true;
                collision.GetComponent<EnemyHealthScript>().takeDMG(m_Dmg, FireT);
                
            }

            if (!collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }

        }
    }

    private void OnDestroy()
    {
        if (Explosive)
        {
            m_particleSystem = m_explosion.GetComponent<ParticleSystem>();
            ParticleSystem.ShapeModule shape = m_particleSystem.shape;
            shape.radius = 4.3f;
            Instantiate(m_explosion, transform.position, transform.rotation);
        }
        
    }
}
