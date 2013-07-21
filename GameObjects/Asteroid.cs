using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	
	//Change from public and settable to private.
	public int id = 0;
	public string objectName = "";
	public int type;
	public int ownerId= 0;
	public int minerals;
	private Rect rect = new Rect(0,0,150,150);
	private bool window = false;
	private int windowId;
	
	void Start(){
		windowId = Globals.windowIdCounter;
		Globals.windowIdCounter++;
	}
	
	void OnMouseOver(){
		if(Input.GetMouseButton (1)){
			if(!window){
				window = true;
				rect.x = Input.mousePosition.x;
				rect.y = Screen.height - Input.mousePosition.y;
			}
		}
	}
	
	void OnMouseDown(){
		Globals.setTarget(this.gameObject, objectName, type);
	}
	
	void OnGUI(){
		if(window){
			rect = GUI.Window(windowId, rect, CreateWindow, objectName);	
		}
	}
	
	void CreateWindow(int windowId){
		GUILayout.BeginHorizontal();
		GUILayout.Label("Minerals: "+minerals);
		GUILayout.EndHorizontal();
		
		//If a fleet is selected, display the fleet menu
		if(Globals.targetType == 2){
			GUILayout.BeginHorizontal();
			if(GUILayout.Button("Send Fleet")){
				//TODO: Send a movement request to the database and update slowly instead of this auto move
				Globals.target.transform.position = this.transform.position;
				Globals.target.transform.Translate(1,0,1);
			}
			GUILayout.EndHorizontal();
			//If a ship is close enough, then display the mine button.
			if(Vector3.Distance(this.transform.position, Globals.target.transform.position) <1.5){
				GUILayout.BeginHorizontal();
				if(GUILayout.Button("Mine")){
					//TODO: Actually do mining calculations
					//TODO: Connect to database
					mine (5);
				}
				GUILayout.EndHorizontal();
			}
			
		}
		GUILayout.BeginHorizontal();
		if(GUILayout.Button ("Close")){
			window = false;
		}
		GUILayout.EndHorizontal();
		GUI.DragWindow();
	}
	
	public void mine(int miningPower){
		//TODO: Add actual mining algorithm...
		//TODO: Connect to database
		//TODO: Check if the fleet is close enough, with database check instead of this.
		//Probably want to do this check on the server too.
		if(Vector3.Distance(this.transform.position, Globals.target.transform.position) <1.5){
			int amountMined = 0;
			if(minerals - miningPower > 0){
				amountMined = miningPower;
				minerals -= miningPower;
			}else if(minerals != 0){
				amountMined = minerals;
				minerals = 0;
			}
			
			//TODO: Add actual adding of items algorithm...
			Globals.items[0].AddAmount(amountMined);
		}
	}
		

}
