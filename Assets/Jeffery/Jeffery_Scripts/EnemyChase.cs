using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour
{
    //var Player : Transform;
    public Transform Player;
    NavMeshAgent agent;
    public float MoveSpeed = 5;
    //public float MaxDist = 10;
    public float chaseDist = 60;
    public float NavD;

    // Use this for initialization
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NavD = Vector3.Distance(Player.transform.position, transform.position);
        if (NavD <= chaseDist)
        {
            agent.SetDestination(Player.gameObject.transform.position);
            agent.Resume();
            //if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            //{
            //    //Here Call any function U want Like Shoot at here or something
            //}
        }
        else
        {
            agent.Stop();
        }
    }
}
