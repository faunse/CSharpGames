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
    private GameObject M_Flash;
    [SerializeField] public ParticleSystem ParticleSystem;
    //[SerializeField] private Vector2 m_lastdirection;
    private InputAction m_attackAction;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        m_attackAction = InputSystem.actions.FindAction("Attack");
    }
    private void Start()
    {
        M_Flash = gameObject.transform.Find("GunSparkLight 2D").gameObject;
        M_Flash.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (m_attackAction.IsPressed() && Time.time > m_FireTimeout)
        {
            m_FireTimeout = Time.time + m_FireRate;
            Fire();
            StartCoroutine(MuzzleFlash());
        }
    }
    public void ChangeWeaponAR()
    {
        m_damage = 100;
        m_FireRate = 0.2f;
    }
    public abstract void AddStats(string stat, float amount);
    protected abstract void Fire();
    public IEnumerator MuzzleFlash()
    {
        M_Flash.SetActive(true);
        ParticleSystem.Play(m_firepoint);
        yield return new WaitForSeconds(0.1f);
        M_Flash.SetActive(false);
    }
}



