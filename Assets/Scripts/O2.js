#pragma strict

function Start () {

}

function Update () {

}

function OnCollisionEnter(col : Collision){
	if (col.transform.name.Equals ("captain-basic")) {
		Oxygen.oxygen += 5;
		Destroy (gameObject);
	}
}