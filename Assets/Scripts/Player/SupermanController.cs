using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupermanController : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject explosionPrefab; 


	public float walkspeed = 1f;

	public bool isAllowedToMove = true;

	void Start(){
		isAllowedToMove = true;
	}

	void Update () {

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-0.1f, 0, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate ( 0.1f, 0, 0);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (0, 0.1f, 0);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate ( 0, -0.1f, 0);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate (bulletPrefab, transform.position, Quaternion.identity);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Enemy") {
			
			// 衝突したときにダメージ受ける
			GameObject.Find ("UI").GetComponent<UIController> ().Damage ();

			// 爆発エフェクトを生成する
			Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			Destroy (col.gameObject);
			//Destroy (gameObject);
		}
		if (col.tag == "Heart") {
			// 衝突したときにライフ増える
			GameObject.Find ("UI").GetComponent<UIController> ().AddLife ();
			Destroy (col.gameObject);
		}
	}
}
