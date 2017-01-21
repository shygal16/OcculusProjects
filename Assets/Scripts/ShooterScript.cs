using UnityEngine;
using System.Collections;

public class ShooterScript : MonoBehaviour {
    private Rigidbody Ball;
    public float minForce=5;
    public float maxForce=15;
    public float currentForce=0;
    private float Angle = 0;
    private bool Kicked = false;
    public Vector3 Ballpos;
	// Use this for initialization
	void Start () {
	
	}
	
    void Awake()
    {
        Ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody>();
        currentForce = minForce;
        Ballpos = Ball.position;
    }
    void ResetGame()
    {
        Angle = 0;
        Kicked = false;
        currentForce = minForce;
        Ball.gameObject.GetComponent<BallScript>().Alive = true;
        Ball.gameObject.SetActive(true);
        Ball.position=Ballpos;
    }
	// Update is called once per frame
	void Update ()
    {
        if(!Kicked)
        {
            Ball.velocity = Vector3.zero;
        Vector3 pos = Ball.transform.position;

	    if(Input.GetKey(KeyCode.LeftArrow))
            {
               pos.x += (5*Time.deltaTime);
            }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x -= (5 * Time.deltaTime);
        }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Angle += (5 * Time.deltaTime);
                if (Angle > 45) { Angle = 45; }
                print("CurrentForce: " + currentForce.ToString() + " , Current Angle: " + Angle.ToString());

            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Angle -= (5 * Time.deltaTime);
                if(Angle<0){ Angle = 0; }
                print("CurrentForce: " + currentForce.ToString() + " , Current Angle: " + Angle.ToString());
            }

            if (Input.GetKey(KeyCode.Space))
        {
            if (currentForce < maxForce)
                currentForce += (2f * Time.deltaTime);
            else
                currentForce = minForce;
            print("CurrentForce: "+ currentForce.ToString()+" , Current Angle: "+ Angle.ToString());
        }
        
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            Kicked = true;
            Ball.AddForce(0.0f, Mathf.Sin(Mathf.Deg2Rad * 15) * currentForce,-Mathf.Cos(Mathf.Deg2Rad*15)*currentForce,ForceMode.Impulse);
        }
          

            Ball.transform.position=pos;
        }
        else if ( Input.GetKeyUp(KeyCode.Space) && Ball.gameObject.GetComponent<BallScript>().Alive==false)
        {
            ResetGame();
        }
        else if (Input.GetKeyUp(KeyCode.R) && Ball.gameObject.GetComponent<BallScript>().Alive == false)
        {
            Ball.gameObject.GetComponent<BallScript>().ResetScore();
        }
    }
}
