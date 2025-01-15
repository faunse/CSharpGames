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
        m_FireRate = 0.5f;
        m_damage = 30;
        m_projectilespeed = 10;
        AddStats("All", 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = m_Sprite2;
        gameObject.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 1);
    }

    protected override void Fire()
    {
        Vector3 PlayerPos = transform.position;
        Vector3 mousepos = Input.mousePosition;
        Vector3 mouseposonscreen = Camera.main.ScreenToWorldPoint(mousepos);
        Vector2 CrossHair = mouseposonscreen - PlayerPos;



        GameObject bullet = Instantiate(m_bullet, m_firepoint.position, Quaternion.identity);

        if (bullet.GetComponent<Rigidbody2D>() != null)
        {
            bullet.GetComponent<Rigidbody2D>().AddForce(CrossHair.normalized * m_projectilespeed, ForceMode2D.Impulse);
        }
    }
}
