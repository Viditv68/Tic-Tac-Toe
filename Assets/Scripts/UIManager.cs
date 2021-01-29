using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[Serializable]
public class UIScreen
{
    public GameObject MainMenu;
    public GameObject GameplayScreen;
}


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    public Dictionary<string, GameObject> Screen;

    public UIScreen uiScreen;
    private void Awake()
    { 
        playButton.onClick.AddListener(StartGame);
        
    }
    private void Start()
    {
        Screen = new Dictionary<string, GameObject>();
        
        Screen.Add("MainMenu", uiScreen.MainMenu);
        Screen.Add("Gameplay", uiScreen.GameplayScreen);
    }

    private void StartGame()
    {
        GameObject obj = null;

        if(Screen.TryGetValue("MainMenu", out obj))
        {
            obj.SetActive(false);
        }
        if(Screen.TryGetValue("Gameplay", out obj))
        {
            obj.SetActive(true);
        }
    }
}
