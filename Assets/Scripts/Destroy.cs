using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
			Destroy (gameObject);
	}
}
