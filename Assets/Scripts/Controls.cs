using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public float SpeedX;
	public float SpeedY;
	public bool grounded;
	public bool facingRight;
	public float LowPoint = -300;
	public Transform SpawnPoint;
	
	public float RunSpeed = 100f;
	public float WalkSpeed = 5f;
	public float JumpForce = 9001f;
	public static int health = 100;
	
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		rigidbody.velocity = Vector3.zero;
		anim = GetComponent<Animator>();
		facingRight = true;
		rigidbody.freezeRotation = true;
	}
	
	void OnCollisionEnter(Collision col){
		if(col.transform.name.Equals("Enemy")) {
			health = health - 2;
			Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);
			rigidbody.AddForce (Vector3.up * JumpForce * .5f);
			//rigidbody.AddForce(Vector3.back * 1000, 0);
			//transform.position = Vector3.MoveTowards(transform.position, transform.position * Vector3.back * 10, step);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position.z = 2.495101;
		//transform.position = new Vector3(transform.position.x,transform.position.y,2.495101);
		Vector3 pos = transform.position;
		Vector3 speed = new Vector3();
		
		//pos.z = 2.495101f;
		transform.position = pos;
		
		/*if (!grounded) {
            //rigidbody.AddForce (Vector3.up * JumpForce);
            speed = rigidbody.velocity; 
            speed.x = speed.x * .9f;
            rigidbody.velocity = speed;
            print ("Anayone here?");
        }*/
		
		SpeedX = rigidbody.velocity.x;
		SpeedY = (grounded) ? 0 : rigidbody.velocity.y;
		
		Orientation ();
		
		anim.SetFloat ("SpeedX", Mathf.Abs (SpeedX));
		anim.SetFloat ("SpeedY", SpeedY);
		anim.SetBool ("Grounded", grounded);
		
		if (grounded && Input.GetButtonDown("Jump")) {
			SpawnPoint.position = this.transform.position;
			rigidbody.AddForce (Vector3.up * JumpForce);
			//speed = rigidbody.velocity; 
			//speed.y = 20;
			//rigidbody.velocity = speed;
		}
		
		if (!grounded) {
			//transform.Translate (Vector3.down * Mathf.Abs (1f) * Time.deltaTime);
			speed = rigidbody.velocity; 
			speed.y = speed.y - 1f;
			//speed.x = speed.x * .99f;
			SpeedX = SpeedX * .95f;
			rigidbody.velocity = speed;
		}
		
		
		
		//SpeedX = rigidbody.velocity.x;
		//rigidbody.velocity.x = SpeedX;
		//speed = rigidbody.velocity;
		//rigidbody.velocity = speed;
		//SpeedX = rigidbody.velocity.x;
		transform.Translate (Vector3.forward * Mathf.Abs (SpeedX) * Time.deltaTime);
		
		if (transform.position.y < LowPoint)
			Respawn ();
	}
	
	void Respawn () {
		Score.score -= 100;
		transform.position = SpawnPoint.position;
	}
	
	void OnTriggerEnter (Collider other) {
		grounded = true;
	}
	
	void OnTriggerExit (Collider other) {
		grounded = false;
	}
	
	void Orientation () {
		//SpeedX = rigidbody.velocity.x * .9f;
		
		//if (grounded) {
		SpeedX = Input.GetAxis ("Horizontal");
		//}
		
		if (Input.GetKey (KeyCode.LeftShift))
			SpeedX *= WalkSpeed;
		else
			SpeedX *= RunSpeed;
		
		if (facingRight && SpeedX < -0.1) {
			rigidbody.freezeRotation = false;
			transform.Rotate (0, 180, 0);
			rigidbody.freezeRotation = true;
			facingRight = false;
			
			//captainNoise2.Play();
		} else if (!facingRight && SpeedX > 0.1) {
			rigidbody.freezeRotation = false;
			transform.Rotate (0, -180, 0);
			rigidbody.freezeRotation = true;
			facingRight = true;
			//captainNoise2.Play();
		}
	}
	
	//    void Movement() {
	//        SpeedX = Input.GetAxis ("Horizontal");
	//
	//        if (Input.GetKey (KeyCode.LeftShift))
	//            SpeedX *= WalkSpeed;
	//        else
	//            SpeedX *= RunSpeed;
	//        
	//        if (facingRight && SpeedX < -0.1) {
	//            transform.Rotate (0, 180, 0);
	//            facingRight = false;
	//            captainNoise2.Play();
	//            
	//        } else if (!facingRight && SpeedX > 0.1) {
	//            transform.Rotate (0, -180, 0);
	//            facingRight = true;
	//            captainNoise2.Play();
	//            
	//        }
	//        
	//        if (!facingRight)
	//            SpeedX *= -1;
	//        
	//        anim.SetFloat ("SpeedX", SpeedX);
	//        
	//        if (SpeedX == 0) {
	//            captainNoise2.Stop();
	//        }
	//    }
}