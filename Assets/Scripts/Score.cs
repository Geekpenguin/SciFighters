using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {	
	public static int score;
	public int health;

	// Use this for initialization
	void Start () {
		score = 0;
		guiText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		health = Controls.health * 10;
		guiText.text = "Score: " + (score + health);
	}
}