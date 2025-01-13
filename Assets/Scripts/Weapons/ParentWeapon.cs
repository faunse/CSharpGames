using System.Buffers;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ParentWeapon : MonoBehaviour
{


    [Header("Projectile Parameters")]
    [SerializeField] protected GameObject m_bullet;
    [SerializeField] protected Transform m_firepoint;
    [SerializeField] protected float m_projectilespeed;
    [SerializeField] protected float m_damage;
    [SerializeField] protected float m_FireRate;
    [SerializeField] protected Sprite m_Sprite;
    protected float m_FireTimeout = 0;
    //[SerializeField] private Vector2 m_lastdirection;
    private InputAction m_attackAction;
    public string m_name = "Alfie";




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_attackAction = InputSystem.actions.FindAction("Attack");
        

    }

    

    // Update is called once per frame
    void Update()
    {
        



        if (m_attackAction.IsPressed() && Time.time > m_FireTimeout)
        {
            m_FireTimeout = Time.time + m_FireRate;
            Fire();
            
            
        }

    }

    public void ChangeWeaponAR()
    {
        m_damage = 100;
        m_FireRate = 0.2f;
    }


    public abstract void AddStats(string stat, float amount);



    protected abstract void Fire();
    
}

