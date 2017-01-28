using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
    public float FireInterval = 1f;
    public GameObject PlantPrefeb;
    public Transform ShotPos;

    private float LastShotTime;

    // Use this for initialization
    void Start()
    {
        LastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        bool canShoot = (LastShotTime + FireInterval) < Time.time;
           // Shoot!
           if (canShoot)
            {
                if (PlantPrefeb != null)
                           {
                               if (ShotPos != null)
                               {
                                   GameObject shot = Instantiate(PlantPrefeb, ShotPos.position, ShotPos.rotation) as GameObject;
                               }
                               else
                               {
                                   GameObject shot = GameObject.Instantiate<GameObject>(PlantPrefeb);
                                   shot.transform.position = transform.position;
                                   shot.transform.forward = transform.forward;
                                   shot.transform.up = transform.up;
                               }
                               LastShotTime = Time.time;
                           }
            }
           
           
    }
}
