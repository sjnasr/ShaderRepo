using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
			Destroy (gameObject);
	}
}
