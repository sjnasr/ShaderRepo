using UnityEngine;
using System.Collections;

public class LoadBundle : MonoBehaviour {
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
			//Instantiate (bundle.LoadAssetAsync(assetName, typeof(GameObject)));
			Debug.Log ("Before asset async");
			AssetBundleRequest request= bundle.LoadAssetAsync(assetName, typeof(GameObject));

			Debug.Log ("After asset async");
			//yield return request;

			GameObject obj = request.asset as GameObject;

			Debug.Log ("Before Instantiate");
			Debug.Log ("bundle.mainasset : " + bundle.mainAsset);
			GameObject newObject = Instantiate (obj) as GameObject;
			Debug.Log ("After Instantiate");

			newObject.transform.parent = this.transform;

			//bundle.Unload (false);

		}
	}

}
