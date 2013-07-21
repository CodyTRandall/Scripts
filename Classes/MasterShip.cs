using UnityEngine;
using System.Collections;

public class MasterShip {
	private int id;
	private string shipName;
	private int miningPower;
	
	public MasterShip (int id, string shipName, int miningPower){
		this.id = id;
		this.shipName = shipName;
		this.miningPower = miningPower;
	}
	
	public int getMiningPower(){
		return miningPower;
	}
	
	public string getName(){
		return shipName;
	}

}
