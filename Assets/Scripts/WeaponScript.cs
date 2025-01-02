using System.Buffers;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{


    [Header("Projectile Parameters")]
    [SerializeField] GameObject m_bullet;
    [SerializeField] Transform m_firepoint;
    [SerializeField] float m_projectilespeed;
    [SerializeField] int m_Bdamage;
    [SerializeField] float m_FireRate;
    private float m_FireTimeout = 0;
    [SerializeField] private Vector2 m_lastdirection;
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
        m_Bdamage = 100;
        m_FireRate = 0.2f;
    }



    void Fire()
    {
        
        Vector3 PlayerPos = transform.position;
        Vector3 mousepos = Input.mousePosition;
        Vector3 mouseposonscreen = Camera.main.ScreenToWorldPoint(mousepos);
        Vector2 CrossHair = mouseposonscreen - PlayerPos;

    

        GameObject bullet = Instantiate(m_bullet, m_firepoint.position, quaternion.identity);

        if (bullet.GetComponent<Rigidbody2D>() != null)
        {
            bullet.GetComponent<Rigidbody2D>().AddForce(CrossHair.normalized * m_projectilespeed, ForceMode2D.Impulse);
        }
    }
}

