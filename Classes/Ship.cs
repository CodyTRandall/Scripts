using UnityEngine;
using System.Collections;

public class Ship {

	private int shipId;
	private int shipType;
	
	public Ship(int shipId, int shipType){
		this.shipId = shipId;
		this.shipType = shipType;
	}
	
	public string GetName(){
		return ShipList.getShip(shipId).getName();
	}
}
