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
    public int Cost;

    private void Update()
    {
        Pscore = gameObject.GetComponentInParent<Score>().m_score;
        
    }

    public void AddFirerate()
    {
        if (Pscore >= Cost)
        {
            FireRate = FireRate + 0.05f;
            GetComponent<ParentWeapon>().AddStats("FireRate", FireRate);
            Score();
        }
    }

    public void AddDamage()
    {
        if (Pscore >= Cost)
        {
            Damage = Damage + 1;
            GetComponent<ParentWeapon>().AddStats("Damage", Damage);
            Score();
        }
    }

    public void AddRange()
    {
        if (Pscore >= Cost)
        {
            range = range + 0.5f;
            GetComponent<ParentWeapon>().AddStats("Range", range);
            Score();
        }
    }

    public void AddHealh()
    {
        if (Pscore >= Cost)
        {
            Health = Health + 10;
            gameObject.GetComponent<HealthScript>().m_MaxHealth = Health;
            gameObject.GetComponent<HealthScript>().m_CurrentHealth += 10;
            Score();
        }

    }


    public void AddSpeed()
    {
        if (Pscore >= Cost)
        {
            gameObject.GetComponent<TopDownCharacterController>().m_playerSpeed += 25;
            Score();
        }

    }

    public void Score()
    {
        gameObject.GetComponent<Score>().Bought(Cost);
    }

    public void BuyAR()
    {
        if (Pscore >= Cost)
        {
            GetComponent<PistolWeapon>().enabled = false;
            GetComponent<Shotgun1Script>().enabled = false;
            GetComponent<ARScript>().enabled = true;
        }
    }

    public void BuyShotgun()
    {
        if (Pscore >= Cost)
        {
            GetComponent<PistolWeapon>().enabled = false;
            GetComponent<Shotgun1Script>().enabled = true;
            GetComponent<ARScript>().enabled = false;
        }
    }

    public void BuyPistol()
    {
        if (Pscore >= Cost)
        {
            GetComponent<PistolWeapon>().enabled = true;
            GetComponent<Shotgun1Script>().enabled = false;
            GetComponent<ARScript>().enabled = false;
        }
    }

    void UpgradeAR()
    {

    }



}
