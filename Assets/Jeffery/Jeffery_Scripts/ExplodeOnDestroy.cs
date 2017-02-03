using UnityEngine;
using System.Collections;

public class ExplodeOnDestroy : MonoBehaviour
{
    public GameObject Prefab;
    public bool CleanUp = false;

    public void OnDestroy()
    {
        GameObject go = Instantiate(Prefab, transform.position, transform.rotation) as GameObject;
        go.name = this.name + ":" + go.name;
        if(CleanUp == true)
        {
            DestroyAfterTime dat = go.AddComponent < DestroyAfterTime >();
            dat.delay = 0.5f;
        }
    }
    
}
