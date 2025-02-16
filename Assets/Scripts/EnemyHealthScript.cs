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
    private bool m_Once;

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
        if (health <= 0 && !m_Once)
        {
            m_Once = true;
            RoundHandler.GetComponent<SpawnerScript>().CountTheDead(L);
            L = 0;
            GameObject.Find("Character").GetComponent<ScoreSystem>().AddScore(30);
            Instantiate(m_Pickup, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
        else
        {
            if (Fire)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 6);
                foreach (Collider2D Enemy in colliders)
                {
                    GameObject Enemys = Enemy.gameObject;
                    if (Enemys.GetComponent<EnemyHealthScript>() != null)
                    {
                        Enemys.GetComponent<EnemyHealthScript>().fire(1);
                    }
                }
            }

        }
       
    }
    public void fire(int a)
    {
        StartCoroutine("FireCoroutine");
    }


    IEnumerator FireCoroutine()
    {
        for (int i = 0; i <= 5; i++)
        {
            health = health - 10;
            m_healthbar.fillAmount = health / maxHealth;
            if (health <= 0)
            {

                RoundHandler.GetComponent<SpawnerScript>().CountTheDead(L);
                L = 0;
                GameObject.Find("Character").GetComponent<ScoreSystem>().AddScore(30);
                Instantiate(m_Pickup, transform.position, transform.rotation);
                Destroy(gameObject);

            }
            yield return new WaitForSeconds(2);
        }


    }



}
