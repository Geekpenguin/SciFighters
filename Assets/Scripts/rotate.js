#pragma strict

function Start () {

}

function Update () {

	transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(180,0,0), Time.time * .000005);

}