using UnityEngine;
using System.Collections;

public class Pistol : MonoBehaviour {
	public GameObject laserPrefab;
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

		if ((Input.GetKeyDown (KeyCode.D) && !facingRight) ||
			(Input.GetKeyDown (KeyCode.A) && facingRight))
			facingRight = !facingRight;

		/*if (facingRight)
			aim.y = -Mathf.Abs (aim.y);
		else
			aim.y = Mathf.Abs (aim.y);*/
		
		//arm.transform.rotation = aim;
	}

	void Fire () {
		var direction = 1;
		if (!facingRight)
			direction = -1;
		var thePosition = new Vector3 (this.transform.position.x + 4*direction, this.transform.position.y, this.transform.position.z);
		var laser = GameObject.Instantiate(laserPrefab, thePosition, this.transform.rotation) as GameObject;
		var newDirection = this.transform.rotation;
		newDirection.x = newDirection.x * direction;

		laser.rigidbody.AddForce(newDirection.x, 0, 0);
		Destroy (laser, 5.0f);
		LaserSound();
	}

	void LaserSound () {
		int random = Random.Range(1, 4);
		//playSound(random);
	}
}
