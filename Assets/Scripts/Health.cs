using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {	 
	// Use this for initialization
	void Start () {
		guiText.text = "Health: " + CharacterMovementWithSound.health;
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Health: " + CharacterMovementWithSound.health;
	}
}
