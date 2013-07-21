using UnityEngine;
using System.Collections;

public class Item {

	private int id;
	private int masterid;
	private int num;
	private string name;
	
	//TODO: Connect to database and set up variables
	public Item(int id, int masterid, int num, string name){
		this.id = id;
		this.masterid = masterid;
		this.num = num;
		this.name = name;
	}
	
	public int GetId(){
		return id;
	}
	
	//Maybe store a cache of all the item stats instead of just storing the masterid
	//But we should also store the master id to determine if they can stack or whatever
	public int GetMasterId(){
		return masterid;
	}
	
	public int GetAmount(){
		return num;
	}
	
	public string GetName(){
		return name;
	}
	
	public void AddAmount(int amount){
		num += amount;
	}
	
}
