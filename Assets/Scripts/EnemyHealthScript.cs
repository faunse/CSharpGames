using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    
    public float health;
    public float maxHealth;
    private GameObject RoundHandler;
    private int L = 1;
    public GameObject m_Pickup;
    public Image m_healthbar;

    private bool heartSpawned = false;

    private void Start()
    {
        RoundHandler = GameObject.Find("RoundHandler");
        health = 15;
        maxHealth = health;
    }



    // Update is called once per frame
    void Update()
    {    
    }

    public void AddHealth(int H)
    {
        health = health + H;
        maxHealth = health;
    }

    public void takeDMG(float incomingDMG, bool Fire)
    {
        health = health - incomingDMG;
        m_healthbar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            
           RoundHandler.GetComponent<SpawnerScript>().CountTheDead(L);
            L = 0;
            GameObject.Find("Character").GetComponent<ScoreSystem>().AddScore();
            //Instantiate(m_Pickup, gameObject.transform, gameObject);
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


    private void OnDestroy()
    {
        Instantiate(m_Pickup, gameObject.transform);
    }
}
