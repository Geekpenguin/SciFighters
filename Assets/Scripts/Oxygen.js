#pragma strict

public static var oxygen: float = 100; // set duration time in seconds in the Inspector

function Update(){
	oxygen -= Time.deltaTime;
	if (oxygen > 100)
		oxygen = 100;
	
 	if (oxygen > 0){
   		guiText.text = "Oxygen: " + oxygen.ToString("F0") + "%";
 	} else {
   		guiText.text = "TIME OVER";
   	}
}