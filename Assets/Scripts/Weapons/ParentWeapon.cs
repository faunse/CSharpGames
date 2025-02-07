using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ParentWeapon : MonoBehaviour
{


    [Header("Projectile Parameters")]
    [SerializeField] protected GameObject m_bullet;
    [SerializeField] protected Transform m_firepoint;
    [SerializeField] protected float m_projectilespeed = 500;
    [SerializeField] protected float m_damage;
    [SerializeField] protected float m_FireRate;
    [SerializeField] protected Sprite m_Sprite;
    [SerializeField] protected float m_FireTimeout = 0;
    [SerializeField] public bool AddFireB;
    [SerializeField] public bool Active;

    [SerializeField] public ParticleSystem ParticleSystem;
    //[SerializeField] private Vector2 m_lastdirection;
    private InputAction m_attackAction;
    public GameObject LightPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
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



    public abstract void AddStats(string stat, float amount);

    protected abstract void Fire();


    public abstract void Light(bool F);


    public void SetActiveWeapon(bool Activate)
    {
        Active = Activate;
        LightPoint.SetActive(Activate);

        if (Activate)
        {
            AddStats("All", 0);
        }
    }


    public IEnumerator Flash()
    {
        Light(true);
        
        yield return new WaitForSeconds(0.05f);
        Light(false);

    }
}



