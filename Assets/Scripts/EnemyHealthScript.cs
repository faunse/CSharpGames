using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    
    public float health;
    private GameObject RoundHandler;
    private int L = 1;

    private void Start()
    {
        RoundHandler = GameObject.Find("RoundHandler");
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth(int H)
    {
        health = health + H;

    }

    public void takeDMG(float incomingDMG, bool Fire)
    {
        health = health - incomingDMG;
        
        if (health <= 0)
        {
            
           RoundHandler.GetComponent<SpawnerScript>().CountTheDead(L);
            L = 0;
           Destroy(gameObject);
        }

        if (Fire)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 50);
            foreach (Collider Enemy in colliders)
            {
                if (Enemy.GetComponent<EnemyHealthScript>() != null)
                {
                    Enemy.GetComponent<EnemyHealthScript>().takeDMG(5, true);

                }


            }

                
              
            
        }
    }
    public void fire()
    {
        StartCoroutine("FireCoroutine");
    }
    IEnumerator FireCoroutine()
    {
        for (int i = 0; i <= 5; i++)
        {
            health = health - 20;
            yield return new WaitForSeconds(2);

        }

    }                                                                                                       
}
