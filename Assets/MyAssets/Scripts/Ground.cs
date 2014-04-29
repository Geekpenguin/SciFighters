using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	public GameObject x;
	GameObject thePlayer;
	//Vector3 pos;
	// Use this for initialization
	void Start () {
		//pos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.position = pos;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{

		x.rigidbody2D.gravityScale = 1;
		if(coll.gameObject.name == "Player")
		{
			coll.gameObject.rigidbody2D.gravityScale = 1;
			Movement playerScript = thePlayer.GetComponent<Movement>();
		    playerScript.jump++;
		}
	} 

	void OnCollisionExit2D(Collision2D col)
	{

		x.rigidbody2D.gravityScale = 1;
		if(col.gameObject.name == "Player")
		{

			col.gameObject.rigidbody2D.gravityScale = 1;
		}
	} 
}
