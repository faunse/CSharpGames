using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    
    public float health;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDMG(float incomingDMG, bool Fire)
    {
        health = health - incomingDMG;
        Debug.Log(incomingDMG);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (Fire)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 50);
            Collider[] hit = colliders;
            
            
            
        }
    }
}
