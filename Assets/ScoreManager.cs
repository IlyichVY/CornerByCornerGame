using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    //private?
    public int Score;
    public int HiScore;


    private void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
    }
    void IncrementScore()
    {
        Score++;
    }
    public void StartScoring()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }
    public void StopScoring()
    {
        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("Score", Score);

        if (PlayerPrefs.HasKey("HiScore"))
        {
            if (Score > PlayerPrefs.GetInt("HiScore"))
            {
                PlayerPrefs.SetInt("HiScore", Score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HiScore", Score);
        }

    }
}
