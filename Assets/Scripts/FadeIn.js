#pragma strict

function Start () {

	renderer.material.color.a  = 0;
	//yield WaitForSeconds(7);

}
 
function Update()
{
    renderer.material.color.a += 0.007;
}