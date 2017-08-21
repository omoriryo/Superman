using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	public GameObject HeartPrefab;

	void Start () {
		InvokeRepeating ("GenerateHeart", 1, 10);
	}

	void GenerateHeart () {
		Instantiate (HeartPrefab, new Vector3 (-2.5f + 5 * Random.value, 6, 0), Quaternion.identity);
	}
}
