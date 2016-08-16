using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
			//Debug.Log(scenePath[1]); // -> "Assets/scene.unity"
			//Application.LoadLevel(scenePath[1]);
			//SceneManager.LoadScene ("shaderrepo");
			//SceneManager.LoadSceneAsync(System.IO.Path.GetFileNameWithoutExtension(scenePath[0]));
			Instantiate (bundle.LoadAsset(assetName));
			#if UNITY_5
			UnityEngine.Object[] mats = Resources.FindObjectsOfTypeAll<Material>();
			#else
			UnityEngine.Object[] mats = bundle.LoadAll(typeof(Material));
			#endif
			foreach(Material mat in mats) {
				if(mat.shader) {
					Shader shaderInBuild = Shader.Find(mat.shader.name);
					//Debug.Log ("Before shader set : " + mat.renderQueue);
					if (shaderInBuild) {
						mat.shader = shaderInBuild;
						//Debug.Log ("After shader set : " + mat.renderQueue);
					}
				}
			}
		}
	}

}
