using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float Age;
    void Start()
    {
        Destroy(gameObject, Age);
        
    }
}
