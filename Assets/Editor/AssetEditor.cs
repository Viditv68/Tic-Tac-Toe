using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(AssetsScript))]
public class AssetEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        List<GameObject> gameobjs = new List<GameObject>();

        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
        {
            gameobjs.Add(obj);
        }

        foreach(GameObject obj in gameobjs)
        {
            if (GUILayout.Button(obj.name))
            {
                AssetsScript asset = (AssetsScript)target;
                asset.GetAssets();
            }
        }
        
    }
}
