using UnityEngine;
using System.Collections;

public class LauncherRotator : MonoBehaviour {

    Vector3 start = new Vector3(-25.0f, 287.0f,46.0f);
    Vector3 end = new Vector3(45.0f, 287.0f, 46.0f);

    public float duration = 20.0f;

    private int state = 0;
    private float timer = 0.0f;
   


    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;
        if(timer>duration)
        {
            state = (state + 1) % 2;
            timer = 0.0f;
        }

        if(state==0)
        {
            transform.eulerAngles = Vector3.Lerp(start, end, timer / duration);
            
        }

        if (state == 1)
        {
            transform.eulerAngles = Vector3.Lerp(end, start, timer / duration);
            
        }
       
    }
}
