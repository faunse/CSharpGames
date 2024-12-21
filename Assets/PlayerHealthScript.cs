using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int health = 100;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            health = health - 20;
        }
        if (collision.CompareTag("Trap"))
        {
            health = health - 100;
        }
        
        
            
    }

}
