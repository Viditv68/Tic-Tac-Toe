using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



[Serializable]
public class UIScreen
{
    public GameObject MainMenu;
    public GameObject GameplayScreen;
    public GameObject HighScoreScreen;

}


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Score score;
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button HighestScoreButton;
    [SerializeField]
    private GameObject highScoreText;

    public Dictionary<int, GameObject> Screen;

    public UIScreen uiScreen;
    private void Awake()
    { 
        playButton.onClick.AddListener(StartGame);
        HighestScoreButton.onClick.AddListener(DisplayHighscore);
        backButton.onClick.AddListener(DisplayMainMenuScreen);
        
    }

    

    private void Start()
    {
        Screen = new Dictionary<int, GameObject>();
        
        Screen.Add(1, uiScreen.MainMenu);
        Screen.Add(2, uiScreen.GameplayScreen);
        Screen.Add(3, uiScreen.HighScoreScreen);
        
    }

    private void DisplayMainMenuScreen()
    {
        
        OnAndOffScreen(3, 1);
    }

    private void DisplayHighscore()
    {
        OnAndOffScreen(1, 3);
        highScoreText.GetComponent<TextMeshProUGUI>().SetText("HighScore: " + score.GetHighScore());
        highScoreText.SetActive(true);
    }

    

    private void StartGame()
    {
        
        OnAndOffScreen(1, 2);
        
    }

    private void OnAndOffScreen(int v1, int v2)
    {
        GameObject obj = null;
        if (Screen.TryGetValue(v1, out obj))
        {
            obj.SetActive(false);
        }
        if (Screen.TryGetValue(v2, out obj))
        {
            obj.SetActive(true);
        }
    }
}
