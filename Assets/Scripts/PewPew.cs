﻿using UnityEngine;
using System.Collections;

public class PewPew : MonoBehaviour {
	public static Sprite sprite;
	public static Light light;
	public static Vector3 SpawnPosition;
	public Quaternion SpawnRotation;
	public float xForce;
	public GameObject bubble1;
	public int FUCK;

	// Use this for initialization
	void Start () {
		xForce = .05f * Pistol.direction;
		constantForce.force = new Vector3(xForce, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//SpawnPosition = GetComponent<Transform> ().position;
		//SpawnRotation = GetComponent<Transform> ().rotation;
	}

	void OnCollisionEnter(Collision col){
		if(col.transform.name.Equals("EnemyWood"))
			Instantiate(bubble1, transform.position, transform.rotation);
		if(!col.transform.name.Equals("laser(Clone)"))
			Destroy(gameObject);
	}


}
