﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ARScript : ParentWeapon
{
    private float TakeAway;
    public Sprite m_sprite2;
    public override void AddStats(string stat, float amount)

    {
        if (stat == "Damage")
        {
            m_damage += amount;
        }
        if (stat == "FireRate")
        {
            m_FireRate -= amount;
            Mathf.Clamp(m_FireRate, 0.05f, 1f);
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
    private void OnEnable()
    {
        m_damage = 15;
        m_FireRate = 0.35f;
        m_projectilespeed = 150;
        AddStats("All", 0);
        gameObject.GetComponentInParent<SpriteRenderer>().sprite = m_sprite2;
       
        LightPoint.SetActive(true);
    }
    protected override void Fire()
    {
        Vector3 PlayerPos = transform.position;
        Vector3 mousepos = Input.mousePosition;
        Vector3 mouseposonscreen = Camera.main.ScreenToWorldPoint(mousepos);
        Vector2 CrossHair = mouseposonscreen - PlayerPos;
        StartCoroutine("Flash");
        GameObject bullet = Instantiate(m_bullet, m_firepoint.position, Quaternion.identity);
        if (bullet.GetComponent<Rigidbody2D>() != null)
        {
            bullet.GetComponent<BulletScript>().BulletStats(m_damage, AddFireB);
            bullet.GetComponent<Rigidbody2D>().AddForce(CrossHair.normalized * m_projectilespeed, ForceMode2D.Impulse);
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
}
