using UnityEngine;
using System.Collections;

public class FleetObject : MonoBehaviour {

	//Change from public and settable to private when we have database access
	public int id = 0;
	public string objectName = "";
	public int type;
	public int ownerId = 0;
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
		if(GUI.Button (new Rect(120,10,28,23),"X")){
			window = false;
		}
		GUI.DragWindow();
	}
	
}
