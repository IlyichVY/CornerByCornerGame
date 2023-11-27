using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void StartGame()
    {
        UiManager.instance.GameStart();
        ScoreManager.instance.StartScoring();
    }
    public void GameOver()
    {
        UiManager.instance.GameOver();
        ScoreManager.instance.StopScoring();
    }

}