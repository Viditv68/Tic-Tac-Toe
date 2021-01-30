using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetsScript : MonoBehaviour
{
    private GameObject[] gameObjects;

    void Start()
    {
    }

    public void GetAssets()
    {
        Debug.Log(Application.dataPath);
        string[] str = AssetDatabase.GetAllAssetPaths();

        foreach(string s in str)
        {
            if(s.Contains("/Assets"))
            {
                Debug.Log(AssetDatabase.AssetPathToGUID(s));

                Object[] obj = AssetDatabase.LoadAllAssetsAtPath(s);

                EditorUtility.CollectDependencies(AssetDatabase.LoadAllAssetsAtPath(s));

            }
        }

    }
}
