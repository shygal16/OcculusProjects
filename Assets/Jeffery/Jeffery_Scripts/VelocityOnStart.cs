using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class VelocityOnStart: MonoBehaviour
{
    public float velocity;

    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector3 forward = transform.forward;
        rb.velocity = forward * velocity;
    }


}
