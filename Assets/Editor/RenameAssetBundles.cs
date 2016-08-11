using UnityEditor;
using System.IO;
using UnityEngine;

public class RenameAssetBundles
{
	[MenuItem("Assets/Rename AssetBundles")]
	static void renameAssetBundles(){
		string[] files = Directory.GetFiles("Assets/StreamingAssets");

		foreach (var a in files){
			if (!a.Contains(".")){
				File.Move(a, a + ".unity3d");
			}
		}
	}
}