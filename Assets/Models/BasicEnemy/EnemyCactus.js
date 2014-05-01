#pragma strict

function Start () {
	//this.animation.Play();
	rigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
	Player1 = GameObject.Find("captain-basic");
}

var MoveSpeed = 10;
var Player : Transform;
var MaxDist = 10;
var MinDist = 1; 
var MaxSep = 10;
var health = 100;
var curY;
var curDist;
var Player1 : GameObject;

function OnCollisionEnter(col : Collision){
		if(col.transform.name.Equals("laser(Clone)")) {
			health = health - 10;
			Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);
			//rigidbody.AddForce(Vector3.back * 1000, 0);
			//transform.position = Vector3.MoveTowards(transform.position, transform.position * Vector3.back * 10, step);
		}
	}
 
function Update () {
	//Player1 = GameObject.Find("player-pistol");
	Player = Player1.transform;
	//print(Player.position);
    transform.LookAt(Player);
    curY=gameObject.transform.position.y;
    //curDist=Vector3.Distance(transform.position, Player.transform.position);
    gameObject.transform.rotation.x=0;
    gameObject.transform.rotation.z=0;
    gameObject.transform.position.z=-.3173;
    var step = 15 * Time.deltaTime;
    
    if(health <= 0){
    	Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);
    	DestroyImmediate(gameObject);
    }
    
  
   if(Vector3.Distance(transform.position,Player.position) >= MaxSep){
   		
    }
   else if(Vector3.Distance(transform.position,Player.position) >= MinDist){
   		animation.Play("EnemyWalk3");
   		transform.position = Vector3.MoveTowards(transform.position, Player.position, step);
        //transform.position.x += Player.transform.position.x*MoveSpeed*Time.deltaTime;  
        //gameObject.transform.rotation.y=266;     
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