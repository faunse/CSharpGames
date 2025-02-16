using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float m_Dmg;
    public bool FireT;
    public bool Explosive;
    private bool m_Once;

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
}
