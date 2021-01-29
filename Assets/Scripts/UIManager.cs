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

    public Dictionary<int, GameObject> Screen;

    public UIScreen uiScreen;
    private void Awake()
    { 
        playButton.onClick.AddListener(StartGame);
        
    }
    private void Start()
    {
        Screen = new Dictionary<int, GameObject>();
        
        Screen.Add(1, uiScreen.MainMenu);
        Screen.Add(2, uiScreen.GameplayScreen);
    }

    private void StartGame()
    {
        GameObject obj = null;

        if(Screen.TryGetValue(1, out obj))
        {
            obj.SetActive(false);
        }
        if(Screen.TryGetValue(2, out obj))
        {
            obj.SetActive(true);
        }
    }
}
