using UnityEngine;
using System.Collections;

public class Pistol : MonoBehaviour {
	public GameObject laserPrefab;
	public GameObject arm;
	public GameObject armAnchor;
	public Camera cam;
	public float bulletSpeed = 50f;
	//public Quaternion aim;
	//public GameObject player;

	private bool facingRight = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Aim ();

		if (Input.GetButtonDown ("Fire1"))
			Fire ();
	}

	void Aim () {
		// use only this line for fixed horizontal orientation
		arm.transform.position = armAnchor.transform.position;

		float z = cam.WorldToScreenPoint(armAnchor.transform.position).z;
		var mouseScreen = Input.mousePosition;
		mouseScreen.z = z;
		var mouse = cam.ScreenToWorldPoint( mouseScreen );
		
		var dir = mouse - armAnchor.transform.position;
		//this.AimDist = dir.magnitude;
		dir.Normalize();
		Quaternion aim = Quaternion.FromToRotation( -Vector3.forward, dir);

		if ((Input.GetKeyDown (KeyCode.D) && !facingRight) ||
			(Input.GetKeyDown (KeyCode.A) && facingRight))
			facingRight = !facingRight;

		if (facingRight)
			aim.y = -Mathf.Abs (aim.y);
		else
			aim.y = Mathf.Abs (aim.y);
		
		arm.transform.rotation = aim;
	}

	void Fire () {
		var laser = GameObject.Instantiate(laserPrefab, this.transform.position, this.transform.rotation) as GameObject;
		var newDirection = this.transform.rotation * Vector2.right;
		laser.rigidbody.velocity = newDirection * bulletSpeed;
		//laser.rigidbody.AddForce (Vector3.forward * bulletSpeed);
		//Destroy (laser, 5.0f);
		//LaserSound();
	}

	void LaserSound () {
		int random = Random.Range(1, 4);
		//playSound(random);
	}
}
