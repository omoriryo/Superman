using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject EnemyPrefab;

	void Start () {
		InvokeRepeating ("GenerateEnemy", 1, 1);
	}

	void GenerateEnemy () {
		Instantiate (EnemyPrefab, new Vector3 (-2.5f + 5 * Random.value, 6, 0), Quaternion.identity);
	}
}
