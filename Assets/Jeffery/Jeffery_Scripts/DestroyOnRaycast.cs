using UnityEngine;
using System.Collections;

public class DestroyOnRaycast : MonoBehaviour
{
    public float range;

    
    public void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if ( Physics.Raycast(ray, range))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 2f);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
        }
    }
}
