using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour
{
    public GameObject coin;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            this.gameObject.active = false;
            Instantiate(coin, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }
}
