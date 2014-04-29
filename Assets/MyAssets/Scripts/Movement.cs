using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	Vector3 x;
	Vector3 speed;
	Quaternion rot;
	public GameObject g;
	public GameObject p;
	public int jump;
	bool atk;
	bool cd;
	public GameObject apo;

	// Use this for initialization
	void Start () {
		x = new Vector3(0,0,0);
		speed = new Vector3(0,0,0);
		rot = gameObject.transform.rotation;
		atk = false;
		cd = true;
		apo.SetActive(false);
		jump = 1;
		//apo.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
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
			gameObject.transform.position = speed;
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



	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(5.0f);
		cd = false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		g.rigidbody2D.gravityScale = 1;
		if(col.gameObject.name == "Cube")
		{

			col.gameObject.rigidbody2D.gravityScale = 1;
		}
	} 

	void OnCollisionExit2D(Collision2D col)
	{

		g.rigidbody2D.gravityScale = 1;
		if(col.gameObject.name == "Player")
		{

			col.gameObject.rigidbody2D.gravityScale = 1;
		}
	} 

	void on()
	{
		apo.SetActive(true);
	}
}
