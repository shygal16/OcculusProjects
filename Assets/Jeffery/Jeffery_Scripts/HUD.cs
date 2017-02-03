using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour
{
    private static HUD sInstance;

    public static HUD Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = FindObjectOfType<HUD>();
            }
            return sInstance;
        }
    }

    public static int Score = 0;
    public static int ShootTimes = 0;
    public static int HitTimes = 0;
    public static float Accuracy = 0f;
    public double b;
    public Text ScoreField;
    public Text ShootTimesField;
    public Text HitTimesField;
    public Text ShootAccuracyField;
    public Image Reload;
    public AudioSource cheer;

    private void Start()
    {
        GameObject go = GameObject.Find("Score");
        if (go != null)
        {
            ScoreField = go.GetComponent<Text>();
        }
        else
        {
            Debug.LogError("Something horrible went wrong.");
        }
        HUD.Instance.AdjustScore(0);
        //HUD.Instance.PlayerAccuracy();
        //Reload.enabled = true;
        //Debug.Log(Reload.enabled);

        Reload.enabled = false;

    }

    void Update()
    {
     
    }
    public void AdjustScore(int value)
    {
        Score += value;
        if (ScoreField != null)
        {
            ScoreField.text = "Score: " + Score;
        }
        cheer.Play();
    }

    

   
}
