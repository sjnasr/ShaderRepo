using UnityEngine;
using System.Collections;

public class BundleLoader : MonoBehaviour {

	public string bundleUrl;

	AssetBundle bundle;

	IEnumerator Start(){
		WWW www = new WWW (bundleUrl);
		yield return www;
		if(www.error != null){
			throw new System.Exception("There's an error " + www.error);
		}

		bundle = www.assetBundle;
	}

	public void Spawn(string assetName){
		if (assetName == "") {
			Instantiate (bundle.mainAsset);
		} else {
			//string[] scenePath = bundle.GetAllScenePaths();
			//Debug.Log(scenePath[0]); // -> "Assets/scene.unity"
			//Application.LoadLevel(scenePath[0]);
			Instantiate (bundle.LoadAsset(assetName));
		}
	}

}
