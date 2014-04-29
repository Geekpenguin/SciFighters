#pragma strict

function Start () {

	renderer.material.color.a  = 0;
	audio.Play();
	//renderer.material.mainTexture.Play();
    yield WaitForSeconds(7);
    //renderer.material.color.a  = 0;
    Application.LoadLevel("mainmenu");

}
  
function Update()
{
    renderer.material.color.a += 0.04;
}