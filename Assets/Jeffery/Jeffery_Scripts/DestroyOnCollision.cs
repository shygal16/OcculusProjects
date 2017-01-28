using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour
{
    private Collider col;

    // Use this for initialization
    void Start()
    {
        col = GetComponent<Collider>();
        if (col == null)
        {
            Debug.LogError("DestroyOnCollision: NO COLLIDER!");
            enabled = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
