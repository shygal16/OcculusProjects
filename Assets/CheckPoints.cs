using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {

    [SerializeField]
    Transform[] goals;
    int currentIndex=-1;
    int score = 0;
    // Use this for initialization
    void Start () {

        //goals = new Vector3[];

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Win()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            ++score;
            ++currentIndex;
            if(currentIndex>=goals.Length)
            {
                Win();
            }
            else
            {
                this.transform.position = goals[currentIndex].position;
               
            }
        }

    }
}
