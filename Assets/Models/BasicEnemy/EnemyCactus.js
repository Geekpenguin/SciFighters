#pragma strict

function Start () {
	//this.animation.Play();
	rigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
}

var MoveSpeed = 10;
var Player : Transform;
var MaxDist = 10;
var MinDist = 1; 
var MaxSep = 10;
var curY;
var curDist;
 
function Update () {
    transform.LookAt(Player);
    curY=gameObject.transform.position.y;
    curDist=Vector3.Distance(transform.position, Player.transform.position);
    gameObject.transform.rotation.x=0;
    gameObject.transform.rotation.z=0;
    
  
   if(Vector3.Distance(transform.position,Player.position) >= MaxSep){
   		
    }
   else if(Vector3.Distance(transform.position,Player.position) >= MinDist){
   		animation.Play();
        transform.position.x += transform.forward.x*MoveSpeed*Time.deltaTime;  
        gameObject.transform.rotation.y=266;     
    	//gameObject.transform.position.y=curY;
    }
    else {
    	//animation.Stop();
    	animation.Play("EnemyAttack3");
    }
    
    if(gameObject.transform.position.y < -175){
    	DestroyImmediate(gameObject);
    }
 
  }