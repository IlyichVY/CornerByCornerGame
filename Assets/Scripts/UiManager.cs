using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField]
    private GameObject _titlePanel;
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    public TextMeshProUGUI score;
    [SerializeField]
    public TextMeshProUGUI highScoreTitle;
    [SerializeField]
    public TextMeshProUGUI highScoreGameOver;
    [SerializeField]
    public TextMeshProUGUI tapText;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        highScoreTitle.text = "High Score: " + PlayerPrefs.GetInt("HiScore").ToString();
    }

    public void GameStart()
    {
        tapText.gameObject.SetActive(false);
        _titlePanel.GetComponent<Animator>().Play("PanelUp");
    }
    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("Score").ToString();//?
        highScoreGameOver.text = PlayerPrefs.GetInt("HiScore").ToString();
        _gameOverPanel.SetActive(true);
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}