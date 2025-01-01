using UnityEngine;

public class PickUpScript : MonoBehaviour
{

    public string Name;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           collision.GetComponentInChildren<WeaponScript>().m_name = Name;
           
        }

    }
}
