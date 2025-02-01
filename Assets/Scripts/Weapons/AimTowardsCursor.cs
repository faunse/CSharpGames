using Unity.Mathematics;
using UnityEngine;

public class AimTowardsCursor : MonoBehaviour
{
 
    void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        Vector2 direction = mousepos - transform.position;

        transform.up = direction;
        // Flips Sprite
        if (gameObject.GetComponent<SpriteRenderer>() != null )
        {
            GetComponent<SpriteRenderer>().flipX = (!(transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 180));

        }
        /*if (!(transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 180))
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }*/
    }
}
