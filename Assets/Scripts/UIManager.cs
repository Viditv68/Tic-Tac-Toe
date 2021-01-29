using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



[Serializable]
public class UIScreen
{
    public GameObject[] screenPanel;
}


public class UIManager : MonoBehaviour
{

    private int mainMenuScreen = 0;
    private int gameplayScreen = 1;
    private int highestScoreScreen = 2; 

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

        for(int i = 0; i < uiScreen.screenPanel.Length; i++)
        {
            Screen.Add(i, uiScreen.screenPanel[i]);
        }
        
    }

    private void DisplayMainMenuScreen()
    {
        
        OnAndOffScreen(highestScoreScreen, mainMenuScreen);
    }

    private void DisplayHighscore()
    {
        OnAndOffScreen(0, 2);
        highScoreText.GetComponent<TextMeshProUGUI>().SetText("HighScore: " + score.GetHighScore());
        highScoreText.SetActive(true);
    }

    

    private void StartGame()
    {
        
        OnAndOffScreen(mainMenuScreen, gameplayScreen);
        
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
