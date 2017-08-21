using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject heartPrefab; 
	int score = 0;
	int life = 1;
	GameObject scoreText;
	GameObject gameOverText;
	Vector3 lifePos = new Vector3(-2.5f, 4.5f, 0.0f);
	Vector3 lifePos2 = new Vector3(0.5f, 0.0f, 0.0f);


	public void GameOver(){
		this.gameOverText.GetComponent<Text>().text = "GameOver";
	}

	public void AddScore(){
		this.score += 10;
	}
	public void Damage(){
		GameObject[] hearts = GameObject.FindGameObjectsWithTag ("UIHeart");
		foreach (GameObject obs in hearts) {
			if(obs.GetComponent<UIHeartController>().num == life){
				Destroy (obs);
			}
		}
		this.life -= 1;

	}
	public void AddLife(){
		if(life <= 2){
			this.life += 1;
			GameObject heart = Instantiate (heartPrefab, lifePos + ((life - 1) * lifePos2), Quaternion.identity);
			heart.GetComponent<UIHeartController>().numLife (this.life);

		}
	}

	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find ("Score");
		this.gameOverText = GameObject.Find ("GameOver");
		GameObject heart = Instantiate (heartPrefab, lifePos, Quaternion.identity);
		heart.GetComponent<UIHeartController>().numLife (this.life);
	}

	void Update () {
		scoreText.GetComponent<Text> ().text = "Score:" + score.ToString("D4");
		if(this.life <= 0){
			// 衝突したときにGameOver表示
			GameOver ();
		}
	}
}
