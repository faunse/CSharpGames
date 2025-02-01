using UnityEngine;
using TMPro;
using UnityEngine.Assertions.Must;

public class ShowPrices : MonoBehaviour
{
    private TMPro.TextMeshProUGUI m_PriceText;
    float m_Price;
    private StorePrices m_Priced;
    public string Item;


        private void Start()
    {
        m_PriceText = (TextMeshProUGUI)GetComponent<TextMeshProUGUI>();
        m_Priced = GetComponentInParent<StorePrices>();

    }

    void Update()
    {
        if ( Item == "Health")
        {
            m_Price = m_Priced.HealthCost;
            m_PriceText.text = "Price: " + m_Price;
        }
        if ( Item == "Damage")
        {
            m_Price = m_Priced.DamageCost;
            m_PriceText.text = "Price " + m_Price;
        }
        if (Item == "Speed")
        {
            m_Price = m_Priced.SpeedCost;
            m_PriceText.text = "Price " + m_Price;
        }
        if (Item == "Range")
        {
            m_Price = m_Priced.RangeCost;
            m_PriceText.text = "Price " + m_Price;
        }
        if (Item == "Rate of fire")
        {
            m_Price = m_Priced.FireRateCost;
            m_PriceText.text = "Price " + m_Price;
        }
    }
}
