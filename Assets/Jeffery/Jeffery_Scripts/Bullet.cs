using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private float Vel=50;
    public Rigidbody rb;
    float timer = 5;
    private PlayerController player;
    void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        rb= GetComponent<Rigidbody>();
        rb.velocity = (transform.forward * Vel)+player.rb.velocity;
    }
    void Update()
    {
    
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Center")
        {
            HUD.Instance.AdjustScore(10);
            Destroy(gameObject);
            
            //float accuracy = PlayerPrefs.GetFloat("Accuracy");
        }
        if (col.gameObject.tag == "Outter")
        {
            HUD.Instance.AdjustScore(2);
            Destroy(gameObject);
            //float accuracy = PlayerPrefs.GetFloat("Accuracy");
        }
     
            Destroy(gameObject);
    }
}
