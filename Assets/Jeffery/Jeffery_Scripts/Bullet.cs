using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float Vel=5;
    void Update()
    {
        transform.position=transform.forward* Vel;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Center")
        {
            HUD.Instance.AdjustScore(10);
            Destroy(col.gameObject);
            //float accuracy = PlayerPrefs.GetFloat("Accuracy");
        }
        if (col.gameObject.tag == "Outter")
        {
            HUD.Instance.AdjustScore(2);
            Destroy(col.gameObject);
            //float accuracy = PlayerPrefs.GetFloat("Accuracy");
        }
        else
        {
            Destroy(this);
        }
    }
}
