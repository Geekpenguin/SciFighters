using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {
	public Transform player;
	//Vector3 x;
	//Vector3 delta;
	//Vector3 speed;
	//Quaternion rot;
	//public GameObject g;
	//public GameObject p;
	//public int jump;
	//bool atk;
	//bool cd;
	//public GameObject apo;

//	private var player;
	public float deadZone = 0.15f;
	public float speed = 1.5f;
	
	// Use this for initialization
	void Start () {

		//delta = new Vector3(0,0,0);
//		speed = new Vector3(0,0,0);
		//rot = gameObject.transform.rotation;
		//x = player.transform.position;
		//atk = false;
		//cd = true;
		//apo.SetActive(false);
		//jump = 1;
		//player = GameObject.Find("player-pistol").transform;
		//apo.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		//delta = player.transform.position - x;
		/*
		gameObject.transform.rotation = rot;
		if (Input.GetKey(KeyCode.RightArrow))
		{
			//rigidbody.AddForce (0, 12, 0);
			speed = gameObject.transform.position;
			speed.x += 0.3f;

			//rigidbody.velocity = speed;
			gameObject.transform.position = speed;
			//p.SetActive(false);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			//rigidbody.AddForce (0, -12, 0);
			speed = gameObject.transform.position;
			speed.x += -0.3f;
			//rigidbody.velocity = speed;
			//p.SetActive(false);
		}
		
		if (Input.GetKey(KeyCode.Space))
		{
			//if(jump > 0){
			//rigidbody.AddForce (0, -12, 0);
			//x = gameObject.transform.position;
			//x.y += 0.5f;
			//rigidbody.velocity = speed;
			//gameObject.transform.position = x;
			//g.rigidbody2D.gravityScale = 1;
			//p.SetActive(false);
			//jump--;
			gameObject.rigidbody2D.velocity = Vector2.up*10;
		}
		
		*/

		//gameObject.transform.position = gameObject.transform.position + delta;
		//x = player.transform.position;


		Vector3 v3 = player.position;
		v3.z = transform.position.z;
		v3.y = v3.y + 20;
		if (Vector3.Distance(v3, player.position) > deadZone)
			transform.position = Vector3.Lerp(transform.position, v3, speed * Time.deltaTime);


	}
	

}
