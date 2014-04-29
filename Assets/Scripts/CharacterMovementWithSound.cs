using UnityEngine;
using System.Collections;

public class CharacterMovementWithSound : MonoBehaviour {
	public static float health;
	public float SpeedX = 0;
	public float SpeedY = 0;
	public float RunSpeed = 5.3057f;
	public float WalkSpeed = 1.513848f;
	public float JumpForce = 1000f;
	public Camera Cam;
	public Transform lowPoint;
	public Transform groundCheck;
	public Transform spawnPoint;
	public LayerMask whatIsGround;
	public Vector3 PlayerPosition;
	public Vector3 CamPosition;

	private Animator anim;
	private bool facingRight = true;
	private bool grounded = false;
	private float groundRadius = 0.2f;

	//"Huh!"
	public AudioSource captainNoise1;
	//"Footsteps"
	public AudioSource captainNoise2;
	//"Ha HA!"
	public AudioSource captainNoise3;
	//"Monster Sounds"
	public AudioSource captainNoise4;
	//"Agh!"
	public AudioSource captainNoise5;
	//Will rename for easier reference.

	void Start() {
		health = 100;
		anim = GetComponent<Animator>();
	}

	void Update() {
		PlayerPosition = transform.position;
		CamPosition = Cam.transform.position;
		float SpeedY = rigidbody2D.velocity.y;
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		anim.SetBool("Ground", grounded);
		anim.SetFloat("SpeedY", SpeedY);
		
		if (grounded) {
			Movement();
			Jump();
		} else {
			Respawn();
		}

		transform.Translate (Vector3.forward * SpeedX * Time.deltaTime);
		CamFollow();
	}

	void CamFollow() {
		CamPosition.Set(PlayerPosition.x, CamPosition.y, CamPosition.z);
		Cam.transform.position = CamPosition;
		Cam.transform.LookAt(transform.position);
	}

	void Movement() {
		SpeedX = Input.GetAxis ("Horizontal");


		if (Input.GetKey (KeyCode.LeftShift))
			SpeedX *= WalkSpeed;
		else
			SpeedX *= RunSpeed;

		if (facingRight && SpeedX < -0.1) {
			transform.Rotate (0, 180, 0);
			facingRight = false;
			captainNoise2.Play();

		} else if (!facingRight && SpeedX > 0.1) {
			transform.Rotate (0, -180, 0);
			facingRight = true;
			captainNoise2.Play();

		}

		if (!facingRight)
			SpeedX *= -1;

		anim.SetFloat ("SpeedX", SpeedX);

		if (SpeedX == 0) {
			captainNoise2.Stop();
				}
	}

	void Jump() {
		if (Input.GetKeyDown (KeyCode.Space)) {
						rigidbody2D.AddForce (Vector3.up * JumpForce);
						//audio.PlayOneShot();
						captainNoise1.Play ();
				}
	}

	void Respawn() {
		if (transform.position.y < lowPoint.position.y) {
			transform.position = spawnPoint.position;
			rigidbody2D.velocity.Set(0, 0);
		}
	}
}