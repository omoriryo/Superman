using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, -0.05f, 0);
		if (transform.position.y < -11.0f ) {
			transform.position = new Vector3 (0, 11.0f, 0);
		}
	}
}
