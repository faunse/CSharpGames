using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float m_Dmg;
    private void OnBecameInvisible()
    {
        
  
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealthScript>().takeDMG(m_Dmg);
            Debug.Log("hit");

        }

        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
