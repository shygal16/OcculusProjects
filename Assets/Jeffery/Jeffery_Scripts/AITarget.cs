using UnityEngine;
using System.Collections;

public class AITarget : MonoBehaviour {

    Vector3 start = new Vector3(130.2f, 33.0f, 131.4f);
    Vector3 end = new Vector3(82.57f, 16.3f, 131.39f);


    public float duration = 20.0f;

    private int state = 0;
    private float timer = 0.0f;



    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > duration)
        {
            state = (state + 1) % 2;
            timer = 0.0f;
        }

        if (state == 0)
        {
            transform.position = Vector3.Lerp(start, end, timer / duration);

        }

        if (state == 1)
        {
            transform.position = Vector3.Lerp(end, start, timer / duration);

        }

    }
}
