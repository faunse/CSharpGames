using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;

public class StatsForWeapons : MonoBehaviour
{

    [SerializeField]
    public float FireRate;
    public float Damage;
    public float range;
    public float Health = 100;
    public float Speed;
    private int Pscore;
    private int Cost2;
    private StorePrices Store;

    public bool A;

    //List<ParentWeapon> Weapons;
    List<GameObject> Weapons;
    

    private void Update()
    {       
        Pscore = gameObject.GetComponentInParent<Score>().m_score;   
    }

    private void Start()
    {
        Store = GameObject.Find("StoreParentCanvas").GetComponent<StorePrices>();       
        Weapons = new List<GameObject>();
        ParentWeapon[] weaponComps = gameObject.GetComponentsInChildren<ParentWeapon>();
        
        foreach (ParentWeapon weapon in weaponComps)
        {
            Weapons.Add(weapon.gameObject);
            Debug.Log("j");
        }

        foreach (GameObject weapon in Weapons)
        {
            weapon.SetActive(false);
        }
    }    
    public void AddFirerate(int Cost)
    {
        Cost = (int)Store.FireRateCost;
        if (Pscore >= Cost)
        {     
            FireRate = FireRate + 0.05f;
            foreach (GameObject weapon in Weapons)
            {
                weapon.GetComponent<ParentWeapon>().AddStats("FireRate", FireRate);
            }
            Score(Cost);
        }
    }
    public void AddDamage(int Cost)
    {
        Cost = (int)Store.DamageCost;
        if (Pscore >= Cost)
        {
            Debug.Log("DamageBought");
            Damage = Damage + 1;
            foreach (GameObject weapon in Weapons)
            {
                weapon.GetComponent<ParentWeapon>().AddStats("Damage", Damage);
            }
            Score(Cost);
        }
    }
    public void AddRange(int Cost)
    {
        Cost = (int)Store.RangeCost;
        if (Pscore >= Cost)
        {
            range = range + 0.5f;
            foreach (GameObject weapon in Weapons)
            {
                weapon.GetComponent<ParentWeapon>().AddStats("Range", range);
            }
            Score(Cost);
        }
    }
    public void AddHealh(int Cost)
    {
        Cost = (int)Store.HealthCost;
        Debug.Log(Cost);
        if (Pscore >= Cost)
        {
            Health = Health + 10;
            gameObject.GetComponentInParent<HealthScript>().m_MaxHealth = Health;
            gameObject.GetComponentInParent<HealthScript>().m_CurrentHealth += 10;
            Debug.Log("Health Updated");
            
            Score(Cost);
        }

    }
    public void AddSpeed(int Cost)
    {
        Cost = (int)Store.SpeedCost;
        if (Pscore >= Cost)
        {
            gameObject.GetComponentInParent<TopDownCharacterController>().m_playerSpeed += 25;
            Score(Cost);
        }
    }
    public void Score(int cost)
    {
        gameObject.GetComponentInParent<Score>().Bought(cost);
    }

    public void BuyAR(int Cost)
    {
        if (Pscore >= Cost)
        {
            Cost = (int)Store.ARcost;
            
            foreach (GameObject weapon in Weapons)
            {
                if (weapon.name.Equals("AKFP"))
                {
                    weapon.SetActive(true);
                    weapon.GetComponent<SpriteRenderer>().enabled = true;
                  
                    weapon.GetComponent<ParentWeapon>().enabled = true;
                    Debug.Log("AR");
                }
                else
                {
                    weapon.SetActive(false);
                    weapon.GetComponent<SpriteRenderer>().enabled = false;
                  
                    weapon.GetComponent <ParentWeapon>().enabled = false;
                    Debug.Log("not");
                }
            }
            Score(Cost);
        }
    }
    public void BuyShotgun(int Cost)
    {
        Cost = (int)Store.shotgunCost;
        if (Pscore >= Cost)
        {
            foreach (GameObject weapon in Weapons)
            {
                if (weapon.name.Equals("SHOTGUNFP"))
                {
                    weapon.SetActive(true);
                    weapon.GetComponent<SpriteRenderer>().enabled = true;
             
                    weapon.GetComponent<ParentWeapon>().enabled = true;
                }
                else
                {
                    weapon.SetActive(false);
                    weapon.GetComponent<SpriteRenderer>().enabled = false;
                  
                    weapon.GetComponent<ParentWeapon>().enabled = false;
                }
            }

            Score(Cost);
        }
    }
    public void BuyPistol(int Cost)
    {
        Cost = (int)Store.PistolCost;
        if (Pscore >= Cost)
        {
            foreach (GameObject weapon in Weapons)
            {
                
                if (weapon.name.Equals("RevolverFP"))
                {
                    weapon.SetActive(true);
                    weapon.GetComponent<SpriteRenderer>().enabled = true;
                  
                    weapon.GetComponent<ParentWeapon>().enabled = true;
                }
                else
                {
                    weapon.SetActive(false);
                    weapon.GetComponent<SpriteRenderer>().enabled = false;
                   
                    weapon.GetComponent<ParentWeapon>().enabled = false;
                }
            }
            Score(Cost);
        }
    }

    public void UpgradeAR(int Cost)
    {
        Cost = (int)Store.UpgradeARcost;
        if (Pscore >= Cost)
        {

            Debug.Log("AR");
            Score(Cost);
            return;           
        }
    }
    public void UpgradeShotgun(int Cost)
    {
        Cost = (int)Store.UpgradeShotgunCost;

        if (Pscore >= Cost)
        {
            Score(Cost);
            GetComponent<Shotgun1Script>().AddFireBullets(12);            
        }
    }
}
