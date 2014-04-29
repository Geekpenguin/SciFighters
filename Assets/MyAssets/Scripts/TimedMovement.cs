using UnityEngine;
using System.Collections;

public class TimedMovement : MonoBehaviour {
	public float velx;
	public float vely;
	public float timerx;
	public float timery;
	public float timecheck;
	float deltaTx;
	float deltaTy;
	float timex;
	float timey;
	Vector2 velxy;
	Vector3 pos;
	
	// Use this for initialization
	void Start () {
		timex = Time.time;
		timey = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		timecheck = Time.time;
		deltaTx = Time.time - timex;
		deltaTy = Time.time - timey;
		velxy.x = 1 * velx;
		velxy.y = 1 * vely;
//		gameObject.rigidbody2D.velocity = velxy;
		if(deltaTx >= timerx){
			velx *= -1;

			timex = Time.time;
		}
		if(deltaTy >= timery){

			vely *= -1;
			timey = Time.time;
		}
	}


}
