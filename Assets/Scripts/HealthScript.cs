using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    private Image m_healthbar;

    [SerializeField]
    public float m_CurrentHealth;
    public float m_MaxHealth = 100;
    public float m_enemydamage;
    

    void Start()
    {
        m_CurrentHealth = m_MaxHealth;
       
        
    }

    
    void Update()
    {
        m_healthbar.fillAmount = m_CurrentHealth / m_MaxHealth;

        if (m_CurrentHealth <= 0)
        {
            die();

        }


        
    }

    void hurt(float amount)
    {
        m_CurrentHealth -= amount;

        if (m_CurrentHealth <= 0)
        {
            die();
        }

    }

    void die()
    {


    }
}
