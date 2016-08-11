using UnityEngine;
using System.Collections;

public class LoadBundle : MonoBehaviour {
	public string url;

	// Note: This example does not check for errors. Please look at the example in the DownloadingAssetBundles section for more information
	IEnumerator Start () {
		while (!Caching.ready)
			yield return null;
		// Start a download of the given URL
		WWW www = WWW.LoadFromCacheOrDownload (url, 1);

		// Wait for download to complete
		yield return www;

		// Load and retrieve the AssetBundle
		AssetBundle bundle = www.assetBundle;

		// Load the object asynchronously
		AssetBundleRequest request = bundle.LoadAssetAsync ("myObject", typeof(GameObject));

		// Wait for completion
		yield return request;

		// Get the reference to the loaded object
		GameObject obj = request.asset as GameObject;

		// Unload the AssetBundles compressed contents to conserve memory
		bundle.Unload(false);

		// Frees the memory from the web stream
		www.Dispose();
	}

}
