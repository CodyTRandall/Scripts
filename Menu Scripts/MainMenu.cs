using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {
	
	private List<MenuObject> menuObjects = new List<MenuObject>();
	
	void Start(){
		menuObjects.Add(new MenuObject("Map"));
		menuObjects.Add(new MenuObject("Fleets"));
		menuObjects.Add(new MenuObject("Character"));
		menuObjects.Add(new MenuObject("Assets"));;
	}
	
	void OnGUI(){
		//Create menu buttons
		GUILayout.BeginArea(new Rect(0,0,70,Screen.height));
		int num = 0;
		menuObjects.ForEach(delegate(MenuObject menuObject){
			GUILayout.Space(10);
			GUILayout.BeginHorizontal();
			if(GUILayout.Button(menuObject.GetName())){
				menuObject.Toggle();
			}
			if(menuObject.GetValue()){
				menuObject.SetRect(GUI.Window(num, menuObject.GetRect(), CreateWindow, menuObject.GetTitle()));
			}
			GUILayout.EndHorizontal();
			num++;
		});
		GUILayout.EndArea();
		
		//Create target GUI
		if(Globals.target != null){
			GUI.Box(new Rect(Screen.width / 2 - 75, 0, 150, 26), Globals.targetName);
		}
	}
	
    void CreateWindow(int windowID) {
		if(windowID == 1){
			//Fleets menu
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();
			GUILayout.Label("Name");
			GUILayout.EndVertical();
			GUILayout.BeginVertical();
			GUILayout.Label("Size");
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
			Globals.fleets.ForEach (delegate(Fleet fleet){
				GUILayout.BeginHorizontal();
				GUILayout.BeginVertical();
				GUILayout.Label(fleet.GetName());
				GUILayout.EndVertical();
				GUILayout.BeginVertical();
				GUILayout.Label(fleet.getSize()+"");
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			});
		}else if(windowID == 3){
			//Assets menu
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();
			GUILayout.Label("Name");
			GUILayout.EndVertical();
			GUILayout.BeginVertical();
			GUILayout.Label("Amount");
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
			Globals.items.ForEach (delegate(Item item){
				GUILayout.BeginHorizontal();
				GUILayout.BeginVertical();
				GUILayout.Label(item.GetName());
				GUILayout.EndVertical();
				GUILayout.BeginVertical();
				GUILayout.Label(item.GetAmount()+"");
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			});
		}else{
	        if(GUI.Button(new Rect(10, 20, 100, 20), "Hello World")){
	            print(Globals.fleets[0].GetName());
			}
		}
		GUI.DragWindow ();
    }
	
}
