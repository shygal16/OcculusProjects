using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    protected OVRCameraRig CameraRig = null;
    public float FlyForce = 15;
    public Rigidbody rb;
    public AudioClip Fire;
    OVRHapticsClip clip;
    // Use this for initialization
    void Start () {
        var p = CameraRig.transform.localPosition;
        CameraRig.transform.localPosition = p;
         clip = new OVRHapticsClip(Fire);
    }
	void Awake()
    {
 
        OVRCameraRig[] CameraRigs = gameObject.GetComponentsInChildren<OVRCameraRig>();

        if (CameraRigs.Length == 0)
            Debug.LogWarning("OVRPlayerController: No OVRCameraRig attached.");
        else if (CameraRigs.Length > 1)
            Debug.LogWarning("OVRPlayerController: More then 1 OVRCameraRig attached.");
        else
            CameraRig = CameraRigs[0];
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update () {
        Vector3 FlyDirection = Vector3.zero;

        //Checks if player's trying to fly and finds direction of flight 
        float LeftTrigger = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
        if (LeftTrigger>0.1f)
        {
            Vector3 temp = CameraRig.leftHandAnchor.forward;
            temp.Normalize();
            FlyDirection += (temp * FlyForce*LeftTrigger);
        }
        //Checks if player's trying to shoot and spawns bullet
        else if (OVRInput.Get(OVRInput.Button.Three))
        {

        }
        float RightTrigger = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);

        //Checks if player's trying to fly and finds direction of flight 
        if (RightTrigger>0.1f)
        {
            
            Vector3 temp = CameraRig.rightHandAnchor.forward;
            temp.Normalize();
            FlyDirection += (temp * FlyForce* RightTrigger);
        }
        //Checks if player's trying to shoot and spawns bullet
        else if (OVRInput.GetDown(OVRInput.Button.One))
        {

        }
           
            OVRHaptics.RightChannel.Queue(clip);

        rb.AddForce(FlyDirection);
    }
}
