using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {	
	public static int score;

	// Use this for initialization
	void Start () {
		score = 0;
		guiText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Score: " + score;
	}
}