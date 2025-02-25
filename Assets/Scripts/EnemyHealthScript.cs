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
    private bool m_OnFire;
    private float m_Dmg;
    private bool m_RNG
    {
        get { return (Random.value > 0.5f); }
    }

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
            GameObject.Find("Character").GetComponent<ScoreSystem>().AddScore(50);
            if (m_RNG)
            {
                Instantiate(m_Pickup, transform.position, transform.rotation);
            }
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
                        Enemys.GetComponent<EnemyHealthScript>().fire(incomingDMG);
                    }
                }
            }

        }
       
    }
    public void fire(float Dmg)
    {
        StartCoroutine(FireCoroutine(m_OnFire, Dmg));
        m_OnFire = true;
    }


    IEnumerator FireCoroutine(bool fire, float Dmg)
    {
        gameObject.GetComponent<ParticleSystem>().Play(true);
        for (int i = 0; i <= 5; i++)
        {
            if (fire)
            {
                i = 0;
            }
            else
            {
                health = health - (Dmg/2f);
                m_healthbar.fillAmount = health / maxHealth;
                if (health <= 0)
                {
                    RoundHandler.GetComponent<SpawnerScript>().CountTheDead(L);
                    L = 0;
                    GameObject.Find("Character").GetComponent<ScoreSystem>().AddScore(100);
                    Instantiate(m_Pickup, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
            yield return new WaitForSeconds(2);
        }
    }



}
