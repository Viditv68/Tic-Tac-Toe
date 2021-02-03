using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Theme",  menuName = "Scriptable Objects/Theme")]
public class Theme : ScriptableObject
{
    public string themeName;
    public List<Color32> theme = new List<Color32>();
}
