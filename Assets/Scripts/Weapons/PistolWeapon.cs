using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class PistolWeapon : ParentWeapon
{
    public float TakeAway;
    public Sprite Sprite;
    private bool Upgraded;


    private void Start()
    {
        
        m_damage = 5;
        m_FireRate = 0.75f;
        m_projectilespeed = 150;
        LightPoint.SetActive(true);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        enabled = true;


    }

    public override void AddStats(string stat, float amount)
    {
        if (stat == "Damage")
        {
            m_damage = m_damage + amount;
            
            
        }
        if (stat == "FireRate")
        {
            m_FireRate -= amount;
            Mathf.Clamp(m_FireRate, 0.1f, 1f);
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
        if (stat == "Upgrade")
        {
            Upgraded = true;
        }

    }
    protected override void Fire()
    {
        {
            if (Active == true)
            {
                Debug.Log("Shoot");
                Vector3 PlayerPos = transform.position;
                Vector3 mousepos = Input.mousePosition;
                Vector3 mouseposonscreen = Camera.main.ScreenToWorldPoint(mousepos);
                Vector2 CrossHair = mouseposonscreen - PlayerPos;
                GameObject bullet = Instantiate(m_bullet, m_firepoint.position, Quaternion.identity);
                StartCoroutine("Flash");
                if (bullet.GetComponent<Rigidbody2D>() != null)
                {
                    m_bullet.GetComponent<BulletScript>().BulletStats(m_damage, false);
                    bullet.GetComponent<Rigidbody2D>().AddForce(CrossHair.normalized * m_projectilespeed, ForceMode2D.Impulse);
                }

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
