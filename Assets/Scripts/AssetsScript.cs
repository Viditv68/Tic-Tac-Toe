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

    public string[] GetAssetsName()
    {
        string[] str = AssetDatabase.GetAllAssetPaths();
        return str;

        /*foreach(string s in str)
        {
            if(s.Contains("/Assets"))
            {
                //Debug.Log(AssetDatabase.AssetPathToGUID(s));
                Debug.Log(s);
                Object[] obj = AssetDatabase.LoadAllAssetsAtPath(s);
                
              

            }
        }*/
    }

    public int InstanceId(string s)
    {
        if(s.Contains("/Assets"))
        {
            Object[] obj = AssetDatabase.LoadAllAssetsAtPath(s);
            
            for(int i = 0; i < obj.Length; i++)
            {
                return obj[i].GetInstanceID();
            }
        }
        return 0;
    }
}
