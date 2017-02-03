using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Text timeText;
    //public int Score;
    public double Acc;
    //public int WinScore = 5;
    public double WinAcc = 55.0;
    
    public float counter = 30.0f;
    
    void Start()
    {
        //Score = 0;
        Acc = 0f;
    }

    void Update()
    {
        //Score = HUD.Score;
        counter -= Time.deltaTime;
        timeText.text = "Time: " + counter.ToString();
        if (counter <= 0)
        {
            if(Acc < WinAcc)
            {
                SceneManager.LoadScene("Defeat");
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
    
  
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
        }

    }



}
