using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    GameObject[] players;
    GameObject target;
    NavMeshAgent agent;
    public float m_ShootRange = 40;
    public float m_Distance;
    public AudioSource Eshoot;

    public float m_FireInterval = 1f;
    public GameObject ShotPrefab;
    public Transform ShotLocation;

    public float m_ReloadTime = 5f;

    private float m_LastShotTime;
    public int m_Bullet;
    public int m_MaxBullet = 10;

    // Use this for initialization
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("AITarget");
        agent = gameObject.GetComponent<NavMeshAgent>();

        m_LastShotTime = Time.time;
        m_Bullet = m_MaxBullet;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if(i == 0)
            {
                m_Distance = Vector3.Distance(players[i].transform.position, transform.position);
                target = players[i];
            }
            else
            {
                if(Vector3.Distance(players[i].transform.position, transform.position) < m_Distance)
                {
                    m_Distance = Vector3.Distance(players[i].transform.position, transform.position);
                    target = players[i];
                }
            }
        }

        bool CanShoot = (m_LastShotTime + m_FireInterval) < Time.time;
        bool HaveAmmo = m_Bullet > 0;
        if (m_Bullet <= 0)
        {
            bool Reloading = (m_LastShotTime + m_ReloadTime) < Time.time;
            if (Reloading)
            {
                m_Bullet = m_MaxBullet;
            }
        }
        if (CanShoot  && HaveAmmo)
        {
            transform.LookAt(target.transform.position);
            if (m_Bullet > 0)
            {

                // Shoot!
                if (ShotPrefab != null)
                {
                    if (ShotLocation != null)
                    {
                        GameObject shot = Instantiate(ShotPrefab, ShotLocation.position, ShotLocation.rotation) as GameObject;
                        Eshoot.Play();
                    }
                    else
                    {
                        GameObject shot = GameObject.Instantiate<GameObject>(ShotPrefab);
                        shot.transform.position = transform.position;
                        shot.transform.forward = transform.forward;
                        shot.transform.up = transform.up;
                    }
                    m_LastShotTime = Time.time;
                }
                --m_Bullet;
            }
        }
        
    }
    
}
