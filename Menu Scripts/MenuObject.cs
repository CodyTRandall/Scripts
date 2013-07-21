using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuObject {
	
	private static Rect defaultRect = new Rect(Screen.width/2 - 200, Screen.height/2 - 150, 400, 300);
	
	private bool val;
	private string name;
	private string title;
	private Rect windowRect;
	
	public MenuObject(string name){
		this.val = false;
		this.name = name;
		this.title = name;
		windowRect = defaultRect;
	}
	
	public MenuObject(string name, string title){
		this.val = false;
		this.name = name;
		this.title = title;
		windowRect = defaultRect;
	}
	
	public bool GetValue(){
		return val;
	}
	
	public void Toggle(){
		val = !val;
	}
	
	public string GetName(){
		return name;
	}
	
	public string GetTitle(){
		return title;
	}
	
	public Rect GetRect(){
		return windowRect;
	}
	
	public void SetRect(Rect newRect){
		windowRect = newRect;
	}
}
