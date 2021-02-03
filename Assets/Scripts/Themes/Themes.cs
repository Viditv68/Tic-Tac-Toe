using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Themes : MonoSingletonGeneric<Themes>
{
    [SerializeField]
    private List<Theme> themes = new List<Theme>();
    private Theme currentTheme;

    [SerializeField]
    private Image MainMenuUI;
    [SerializeField]
    private Image GamplayUI;



    public Theme CurrentTheme { get => currentTheme; set => currentTheme = value; }
    public List<Theme> themesList { get => themes; set => themes = value; }

    public void SetTheme(string themeName)
    {

        foreach(Theme t in themesList)
        {
            if(t.name == themeName)
            {
                currentTheme = t;
                Debug.Log(currentTheme.name);
                break;
            }
            
        }
        if (currentTheme != null)
        {
            MainMenuUI.color = currentTheme.theme[0];
            GamplayUI.color = currentTheme.theme[1];
            //GridUI.color = currentTheme.theme[1];
        }
    }
}
