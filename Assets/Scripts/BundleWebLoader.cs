using UnityEngine;
using System.Collections;

public class BundleWebLoader : MonoBehaviour
{
    public Transform parent;
    public string url = "https://drive.google.com/uc?export=download&id=1ZwCszUNHbLykiOevm2m1T_PkuLGNSiUL";
    public string assetName = "MainMenu";

    private IEnumerator Start()
    {
        using(WWW web = new WWW(url))
        {
            yield return web;

            AssetBundle remoteAssetBundle = web.assetBundle;
            if(remoteAssetBundle == null)
            {
                Debug.Log("could not load");
                yield break;
            }

            GameObject obj =  Instantiate(remoteAssetBundle.LoadAsset(assetName), parent) as GameObject;
            obj.transform.SetAsFirstSibling();
            remoteAssetBundle.Unload(false);
        }
    }
}