using UnityEngine;
using System.Collections;

public class Pistol : MonoBehaviour {
	public GameObject laserPrefab;
	public static float direction;
	//public GameObject arm;
	//public GameObject armAnchor;
	//public Camera cam;
	//public float bulletSpeed = 50f;
	//public Quaternion aim;
	//public GameObject player;

	private bool facingRight = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Aim ();

		if (Input.GetKeyDown(KeyCode.Z))						
			Fire ();
	}

	void Aim () {
		// use only this line for fixed horizontal orientation
		//arm.transform.position = armAnchor.transform.position;

		//float z = cam.WorldToScreenPoint(armAnchor.transform.position).z;
		//var mouseScreen = Input.mousePosition;
		//mouseScreen.z = z;
		//var mouse = cam.ScreenToWorldPoint( mouseScreen );
		
		//var dir = mouse - armAnchor.transform.position;
		//this.AimDist = dir.magnitude;
		//dir.Normalize();
		//Quaternion aim = Quaternion.FromToRotation( -Vector3.forward, dir);

		if ((Input.GetKeyDown (KeyCode.D) && !facingRight) 			||
		    (Input.GetKeyDown (KeyCode.RightArrow) && !facingRight) ||
		    (Input.GetKeyDown (KeyCode.LeftArrow) && facingRight)	||
			(Input.GetKeyDown (KeyCode.A) && facingRight))
			facingRight = !facingRight;

		/*if (facingRight)
			aim.y = -Mathf.Abs (aim.y);
		else
			aim.y = Mathf.Abs (aim.y);*/
		
		//arm.transform.rotation = aim;
	}

	void Fire () {
		direction = 1f;
		if (!facingRight)
			direction = -1f;
		var thePosition = new Vector3 (this.transform.position.x + 5f*direction, this.transform.position.y, this.transform.position.z);
		var laser = GameObject.Instantiate(laserPrefab, thePosition, this.transform.rotation) as GameObject;
		var newDirection = this.transform.rotation;
		newDirection.x = newDirection.x * direction;

		laser.rigidbody.AddForce(newDirection.x, 0, 0);
		laser.rigidbody.velocity = new Vector3(5.4f*direction,0,0);
		Destroy (laser, 2.0f);
		LaserSound();
	}

	void LaserSound () {
		int random = Random.Range(1, 4);
		//playSound(random);
	}
}
