using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fleet {

	private List<Ship> ships = new List<Ship>();
	private string fleetName;
	
	public Fleet(string fleetName){
		this.fleetName = fleetName;
	}
	
	public string GetName(){
		return fleetName;
	}
	
	public int getSize(){
		return ships.Count;
	}
	
	public void AddShip(Ship addedShip){
		ships.Add(addedShip);
	}
}
