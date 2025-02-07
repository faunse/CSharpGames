using UnityEngine;

public class PickupHealthScript : MonoBehaviour
{
    private void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthScript>().AddHealth(20);
            Destroy(gameObject);
        }
    }
}
