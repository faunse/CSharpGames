﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Shotgun1Script : ParentWeapon
{
    private float TakeAway;
    public Sprite m_Sprite2;
    private StatsForWeapons m_stats;

    public Transform m_Left;
    public Transform m_Right;

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
            m_damage = GetComponentInParent<StatsForWeapons>().Damage + m_damage;
            TakeAway = GetComponentInParent<StatsForWeapons>().FireRate;
            m_FireRate = m_FireRate - TakeAway;
        }

    }


 
    

    private void Start()
    {
        m_FireRate = 0.8f;
        m_damage = 12;
        m_projectilespeed = 10;
 ;
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

        if (Active == true)
        {
            Vector3 PlayerPos2 = transform.position;
            Vector3 mousepos2 = Input.mousePosition;
            Vector3 mouseposonscreen2 = Camera.main.ScreenToWorldPoint(mousepos2);
            Vector2 CrossHair = mouseposonscreen2 - PlayerPos2;
            //Deals with bullet spread
            int bulletAmount = 20;
            StartCoroutine("Flash");
            for (int i = 0; i < bulletAmount; i++)
            {
                // interpolates between two given points and assigns each pellet a new position within that lerp
                Vector3 fireDirection = new Vector3(
                    Mathf.Lerp(m_Left.position.x, m_Right.position.x, (float)i / (float)bulletAmount),
                    Mathf.Lerp(m_Left.position.y, m_Right.position.y, (float)i / (float)bulletAmount),
                    Mathf.Lerp(m_Left.position.z, m_Right.position.z, (float)i / (float)bulletAmount)
                    ) - transform.parent.position;
                GameObject bullet = Instantiate(m_bullet, m_firepoint.position, Quaternion.identity);
                bullet.GetComponent<BulletScript>().BulletStats(m_damage, AddFireB);
                bullet.GetComponent<Rigidbody2D>().AddForce(fireDirection.normalized * m_projectilespeed, ForceMode2D.Impulse);
            }

        }

    }

    public override void Light(bool F)
    {
        if (F)
        {
            LightPoint.GetComponent<Light2D>().enabled = true;
        }
        else
        {
            LightPoint.GetComponent<Light2D>().enabled = false;
        }
    }

    /*public override void SetActiveWeapon(bool Activate)
    {
        if (Active)
        {
            AddStats("All", 0);
            LightPoint.SetActive(true);
            Active = Activate;

        }
        else
        {
            LightPoint.SetActive(false);
            Active = Activate;
        }


    }*/
}
