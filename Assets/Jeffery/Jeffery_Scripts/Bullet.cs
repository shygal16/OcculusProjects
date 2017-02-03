using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Plate")
        {
            HUD.Instance.AdjustScore(1);
            HUD.Instance.Hit(1);

            //float accuracy = PlayerPrefs.GetFloat("Accuracy");
        }
    }
}
