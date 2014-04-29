using UnityEngine;
using System.Collections;

public class Platformmotion : MonoBehaviour {
	public int velx;
	public int llimx;
	public int rlimx;
	public int vely;
	public int blimy;
	public int tlimy;
	Vector2 velxy;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		pos = gameObject.transform.position;
		velxy = new Vector2(velx, vely);
	}
	
	// Update is called once per frame
	void Update () {
		pos = gameObject.transform.position;
		if ((velx == 0) || (vely == 0)) {
		if ((pos.x <= llimx) || (pos.x >= rlimx)){
				velx *= -1;}
		
		if ((pos.y <= blimy) || (pos.y >= tlimy)){
				vely *= -1;}
		if (velx == 0)
		gameObject.rigidbody2D.velocity = Vector2.up*vely;
		else
		gameObject.rigidbody2D.velocity = Vector2.right*velx;
		}
		else {

			if ((pos.x <= llimx) || (pos.x >= rlimx))
				velx *= -1;
			if ((pos.y <= blimy) || (pos.y >= tlimy))
				vely *= -1;
			velxy.x = 1 * velx;
			velxy.y = 1 * vely;
			gameObject.rigidbody2D.velocity = velxy;

		}
	}
}
