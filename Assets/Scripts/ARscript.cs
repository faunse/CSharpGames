﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ArScript : ParentWeapon
{
    private void Awake()
    {
        m_damage = 15;
        m_FireRate = 0.1f;
        m_projectilespeed = 15;
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
