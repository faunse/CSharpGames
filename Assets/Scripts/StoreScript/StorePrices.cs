using UnityEngine;

public class StorePrices : MonoBehaviour
{


    public float HealthCost = 100;
    public float SpeedCost = 100;
    public float DamageCost = 80;
    public float RangeCost = 60;
    public float FireRateCost = 80;
    public float PistolCost = 50;
    public float shotgunCost = 250;
    public float ARcost = 500;
    private Score m_scoreSystem;
    private float PSCORE;
    public float UpgradeARcost = 2500;
    public float UpgradeShotgunCost = 1500;
    public float UpgradePistolCost = 5000;

    private void Start()
    {
        m_scoreSystem = GameObject.Find("Character").GetComponent<Score>();
        
    }

    private void Update()
    {
        PSCORE = m_scoreSystem.m_score;
        
    }



    public void HealthBuy()
    {
        if (PSCORE >= HealthCost)
        {

            HealthCost = HealthCost + HealthCost * 0.2f;
            HealthCost = Mathf.RoundToInt(HealthCost);
        }
    }
    public void SpeedBuy()
    {
        if (PSCORE >= SpeedCost)
        { 
            SpeedCost = SpeedCost * 1.5f;
        }
    }
    public void DamageBuy()
    {
        if (PSCORE >= DamageCost)
        {
            DamageCost = DamageCost * 2;
        }
    }

    public void RangeBuy()
    {
        if (PSCORE >= RangeCost)
        {
            RangeCost = RangeCost * 2;
        }
    }

    public void FireRateBuy()
    {
        if (PSCORE >= FireRateCost)
        { 
            FireRateCost = FireRateCost * 1.5f;
        }
    }

 

}
