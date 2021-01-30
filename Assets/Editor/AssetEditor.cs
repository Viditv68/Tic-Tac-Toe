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

        AssetsScript asset = (AssetsScript)target;
        string[] str = asset.GetAssetsName();

        foreach(string s in str)
        {
            string newString = s.Substring(s.LastIndexOf('/') + 1, s.Length - s.LastIndexOf('/') - 1);
            if(GUILayout.Button(newString))
            {
                int id = asset.InstanceId(s);
                foreach(GameObject ob in gameobjs)
                {
                    if(id == ob.GetInstanceID())
                    {
                        Debug.Log(ob.name);
                    }
                }
            }
        }

    }
}
