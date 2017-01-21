using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
    public bool Alive = true;
	// Use this for initialization
	void Awake () {
     }
	void ShooterScore()
    {
        ScoreUI.m_Instance.ShooterAddScore(1);
        Alive = false;
        this.gameObject.SetActive(Alive);
        print("Shooter scored!");
    }
    void GoalieScore()
    {
        ScoreUI.m_Instance.GoalieAddScore(1);
        Alive = false;
        this.gameObject.SetActive(Alive);
        print("GOALIE SAVED!");
    }
   public void ResetScore()
    {
        ScoreUI.m_Instance.Reset();
    }
    void OutOfBounds()
    {
        Alive = false;
        this.gameObject.SetActive(Alive);
        print("OutOfBounds!");
    }
	// Update is called once per frame
	void Update () {
	}
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            ShooterScore();
        }
      
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Goalie"))
        {
            GoalieScore();
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.CompareTag("PlayArea"))
        {
            OutOfBounds();
        }

    }
}
