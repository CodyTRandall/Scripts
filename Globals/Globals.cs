using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Globals : MonoBehaviour {

	public static string baseUrl = "http://www.playconquest.com/unitycq/";
	public static int id = 0;
	public static string username = "TestingName";
	public static double offsetX = -9.5;
	public static double offsetZ = 11;
	public static List<Fleet> fleets = new List<Fleet>();
	public static GameObject target;
	public static string targetName;
	public static int targetType;
	public static int windowIdCounter = 5;
	public static List<Item> items = new List<Item>();
	
	
	public static void setTarget(GameObject target, string targetName, int targetType){
		if(Globals.target != null){
			Globals.target.BroadcastMessage("RemoveTarget");
		}
		target.BroadcastMessage("SetTarget");
		Globals.target = target;
		Globals.targetName = targetName;
		Globals.targetType = targetType;
	}
	
	//Add dummy data, should load the player's actual fleets from the database on load.
	void Start(){
		Fleet testFleet = new Fleet("MiningFleet 1");
		testFleet.AddShip(new Ship(0,0));
		fleets.Add(testFleet);
		
		//Should load a player's actual items from the database on load
		items.Add(new Item(0,0,1,"Minerals"));
	}
}
