using UnityEngine;
using System.Collections;

    using VR = UnityEngine.VR;
public class P1 : MonoBehaviour {
    // Use this for initialization
    Vector3 initialPos;
    public float MovementScale = 2;
	void Start () {
        initialPos = VR.InputTracking.GetLocalPosition(VR.VRNode.CenterEye);

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 CurrentPos= VR.InputTracking.GetLocalPosition(VR.VRNode.CenterEye);
        CurrentPos -= initialPos;
        CurrentPos *= MovementScale;
        CurrentPos += initialPos;
       // this.transform.position = CurrentPos;
       //Change this to calculate the initial position of the cylinder in regards to the camera so when changing 
    }

    void OntriggerStay(Collider other)
    {
        if(other.GetComponent<BallScript>() != null)
        {
            Debug.Log("P1 Wins!");
        }
    }
}
