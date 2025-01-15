using Unity.Mathematics;
using UnityEngine;

public class AimTowardsCursor : MonoBehaviour
{
 
    void Update()
    {
        
        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        Vector2 direction = new Vector2(mousepos.x - transform.position.x, mousepos.y - transform.position.y );

 

        transform.up = direction;

        if (transform.rotation.z <= 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }



    }
}
