using UnityEngine;
using System.Collections;

public class PewPew : MonoBehaviour {
	public static Sprite sprite;
	public static Light light;
	public static Vector3 SpawnPosition;
	public Quaternion SpawnRotation;

	// Use this for initialization
	void Start () {
		//sprite = GetComponent<Sprite>;
		//light = GetComponent<Light>;
	}
	
	// Update is called once per frame
	void Update () {
		SpawnPosition = GetComponent<Transform> ().position;
		SpawnRotation = GetComponent<Transform> ().rotation;
	}

	void OnCollisionEnter(Collision col){
		Destroy(gameObject);
	}
}
