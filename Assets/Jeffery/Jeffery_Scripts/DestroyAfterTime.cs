using UnityEngine;
using System.Collections;
using System;

public class DestroyAfterTime : MonoBehaviour
{
    public float delay = 1f;
    public void Start()
    {
        //Destroy(this.gameObject, delay);
        //Invoke("DestroyMe", delay);

        StartCoroutine(DestroyCallback());
    }

    private IEnumerator DestroyCallback()
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
