using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUI : MonoBehaviour {

    static public ScoreUI m_Instance;
    private Text ScoreText;
    private int ShootScore;
    private int GoalieScore;
	// Use this for initialization
	void Awake () {
        m_Instance = this;
        ScoreText = this.GetComponent<Text>();
        ScoreText.text = "GoalieScore: 0\nShootScore: 0";
    }
	
    public void ShooterAddScore(int value)
    {
        ShootScore += value;
        ScoreText.text = "GoalieScore: " + GoalieScore.ToString() + "\n" + "ShootScore: " + ShootScore.ToString() + "\n";
    }

    public void GoalieAddScore(int value)
    {
        GoalieScore += value;
        ScoreText.text = "GoalieScore: " + GoalieScore.ToString() + "\n" + "ShootScore: " + ShootScore.ToString() + "\n";
    }

    public void Reset()
    {
        ShootScore = 0;
        GoalieScore = 0;
        ScoreText.text = "GoalieScore: " + GoalieScore.ToString() + "\n" + "ShootScore: " + ShootScore.ToString() + "\n";
    }
}
