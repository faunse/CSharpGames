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

    public void takeDMG(float incomingDMG)
    {
        health = health - incomingDMG;
        Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
