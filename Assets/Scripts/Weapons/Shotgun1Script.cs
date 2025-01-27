using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Shotgun1Script : ParentWeapon
{
    private float TakeAway;
    public Sprite m_Sprite2;
    private StatsForWeapons m_stats;

    public override void AddStats(string stat, float amount)
    {
        if (stat == "Damage")
        {
            m_damage += amount;
        }
        if (stat == "FireRate")
        {
            m_FireRate -= amount;
            Mathf.Clamp(m_FireRate, 0.3f, 1f);
        }
        if (stat == "Range")
        {
            Debug.Log("No");

        }
        if (stat == "All")
        {
            m_damage = GetComponent<StatsForWeapons>().Damage + m_damage;
            TakeAway = GetComponent<StatsForWeapons>().FireRate;
            m_FireRate = m_FireRate - TakeAway;
        }

    }


 
    

    private void OnEnable()
    {
        m_FireRate = 0.8f;
        m_damage = 30;
        m_projectilespeed = 200;
        AddStats("All", 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = m_Sprite2;
        gameObject.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 1);
        m_stats = GetComponent<StatsForWeapons>();
    }

    public void AddFireBullets(int i)
    {
        AddFireB = true;
        
    }

    protected override void Fire()
    {
        Fire2();
        return;
    }

    private void Fire2()
    {
        Vector3 PlayerPos2 = transform.position;
        Vector3 mousepos2 = Input.mousePosition;
        Vector3 mouseposonscreen2 = Camera.main.ScreenToWorldPoint(mousepos2);
        Vector2 CrossHair = mouseposonscreen2 - PlayerPos2;

        //Deals with bullet spread
        int bulletAmount = 12;
        for (int i = 0; i < bulletAmount; i++)
        {
            // interpolates between two given points and assigns each pellet a new position within that lerp
            Vector3 fireDirection = new Vector3(
                Mathf.Lerp(m_stats.m_Left.position.x, m_stats.m_Right.position.x, (float)i / (float)bulletAmount),
                Mathf.Lerp(m_stats.m_Left.position.y, m_stats.m_Right.position.y, (float)i / (float)bulletAmount),
                Mathf.Lerp(m_stats.m_Left.position.z, m_stats.m_Right.position.z, (float)i / (float)bulletAmount)
                ) - transform.parent.position;

            GameObject bullet = Instantiate(m_bullet, m_firepoint.position, Quaternion.identity);
            bullet.GetComponent<BulletScript>().BulletStats(m_damage, AddFireB);
            bullet.GetComponent<Rigidbody2D>().AddForce(fireDirection.normalized * m_projectilespeed, ForceMode2D.Impulse);
        }



    }
}
