using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

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
    

    private void Update()
    {
        
        Pscore = gameObject.GetComponentInParent<Score>().m_score;
        
    }

    private void Start()
    {
        Store = GameObject.Find("StoreParentCanvas").GetComponent<StorePrices>();
        
    }

    public void AddFirerate(int Cost)
    {
        Cost = (int)Store.FireRateCost;
        if (Pscore >= Cost)
        {
            
            FireRate = FireRate + 0.05f;
            GetComponent<ParentWeapon>().AddStats("FireRate", FireRate);
            Score(Cost);
        }
    }

    public void AddDamage(int Cost)
    {
        Cost = (int)Store.DamageCost;
        if (Pscore >= Cost)
        {
            Damage = Damage + 1;
            GetComponent<ParentWeapon>().AddStats("Damage", Damage);
            Score(Cost);
        }
    }

    public void AddRange(int Cost)
    {
        Cost = (int)Store.RangeCost;
        if (Pscore >= Cost)
        {
            range = range + 0.5f;
            GetComponent<ParentWeapon>().AddStats("Range", range);
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
            gameObject.GetComponent<TopDownCharacterController>().m_playerSpeed += 25;
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
            GetComponent<PistolWeapon>().enabled = false;
            GetComponent<Shotgun1Script>().enabled = false;
            GetComponent<ARScript>().enabled = true;
        }
    }

    public void BuyShotgun(int Cost)
    {
        if (Pscore >= Cost)
        {
            GetComponent<PistolWeapon>().enabled = false;
            GetComponent<Shotgun1Script>().enabled = true;
            GetComponent<ARScript>().enabled = false;
        }
    }

    public void BuyPistol(int Cost)
    {
        if (Pscore >= Cost)
        {
            GetComponent<PistolWeapon>().enabled = true;
            GetComponent<Shotgun1Script>().enabled = false;
            GetComponent<ARScript>().enabled = false;
        }
    }

    void UpgradeAR(int Cost)
    {

    }



}
