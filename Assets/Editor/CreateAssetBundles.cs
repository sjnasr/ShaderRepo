using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateAssetBundles : MonoBehaviour {

	[MenuItem ("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles(){
		BuildPipeline.BuildAssetBundles ("Assets/Demo", BuildAssetBundleOptions.None ,BuildTarget.StandaloneOSXUniversal);
	}
}
