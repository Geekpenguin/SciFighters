using UnityEngine;
using System.Collections;

public class TestCam : MonoBehaviour {
	public Vector3 speed;
	public float x;
	// Use this for initialization
	void Start () {
		speed = new Vector3(0,0,0);
		x = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow))
		{
			//rigidbody.AddForce (0, 12, 0);
			speed = gameObject.transform.position;
			speed.x += x;
			gameObject.transform.position = speed;

			
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			//rigidbody.AddForce (0, -12, 0);
			speed = gameObject.transform.position;
			speed.x += -x;
			//rigidbody.velocity = speed;
			gameObject.transform.position = speed;

		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			//rigidbody.AddForce (0, 12, 0);
			speed = gameObject.transform.position;
			speed.y += x;
			gameObject.transform.position = speed;
			
			
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			//rigidbody.AddForce (0, -12, 0);
			speed = gameObject.transform.position;
			speed.y += -x;
			//rigidbody.velocity = speed;
			gameObject.transform.position = speed;
			
		}
	
	}
}
