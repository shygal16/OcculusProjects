using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Shoot : MonoBehaviour
{
    public float FireInterval = 1f;
    public GameObject ShotPrefab;
    public Transform ShotLocation;
    public float ReloadTime = 5f;
    public AudioSource shoot;

    private float LastShotTime;
    public static int bullet;
    public int bulletNum = 6;
    
    public Text ammoText;

    // Use this for initialization
    void Start()
    {
        LastShotTime = Time.time;
        bullet = bulletNum;

    }

    // Update is called once per frame
    void Update()
    {
        bool canShoot = (LastShotTime + FireInterval) < Time.time;
        bool haveAmmo = bullet > 0;
        if (bullet <= 0)
        {
            bool Reloading = (LastShotTime + ReloadTime) < Time.time;
            if(Reloading)
            {
                bullet = bulletNum;
            }
        }
        if (canShoot && Input.GetButton("Fire1") && haveAmmo)
        {
            if (bullet > 0)
            {

                // Shoot!
                if (ShotPrefab != null)
                {
                    if (ShotLocation != null)
                    {
                        GameObject shot = Instantiate(ShotPrefab, ShotLocation.position, ShotLocation.rotation) as GameObject;
                        shoot.Play();
                    }
                    else
                    {
                        GameObject shot = GameObject.Instantiate<GameObject>(ShotPrefab);
                        shot.transform.position = transform.position;
                        shot.transform.forward = transform.forward;
                        shot.transform.up = transform.up;
                    }
                    LastShotTime = Time.time;
                }
                HUD.Instance.PlayerShoots(1);
                
                --bullet;
            }
        }
                ammoText.text = "Ammo: " + bullet.ToString();
    }
}
