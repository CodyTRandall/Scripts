using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipList : MonoBehaviour{
	private static List<MasterShip> shipList = new List<MasterShip>();
	
	//Dummy data, Should be updated by the DB when the game loads
	void Start(){
		shipList.Add(new MasterShip(0,"Mining Barge", 5));
	}
	
	public static MasterShip getShip(int shipId){
		return shipList[shipId];
	}
}
