using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float m_Dmg;
    public bool FireT;
    private void OnBecameInvisible()
    {
        
  
    }

    public void BulletStats(float m_dmg, bool A)
    {
        m_Dmg = m_dmg;
        FireT = A;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealthScript>().takeDMG(m_Dmg,FireT);
            Debug.Log("hit");

        }

        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
