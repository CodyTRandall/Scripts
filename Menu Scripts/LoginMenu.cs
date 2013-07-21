using UnityEngine;
using System;
using System.Collections;

public class LoginMenu : MonoBehaviour {

	private int boxWidth = 400;
	private int boxHeight = 350;
	private int borderLength = 20;
	private string email = "";
	private string password = "";
	
	void OnGUI(){
        GUI.Box(new Rect((Screen.width - boxWidth) / 2, (Screen.height - boxHeight) / 2, 400, 300), "Conquest");
        GUILayout.BeginArea(new Rect((Screen.width - boxWidth + borderLength) / 2 , (Screen.height - boxHeight + borderLength) / 2, 400 - borderLength * 2, 300 - borderLength *2));
		
		GUILayout.Space(75);
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Email:", GUILayout.Width(75));
		email = GUILayout.TextField(email);
		GUILayout.EndHorizontal();
		
		GUILayout.Space(50);
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Password:", GUILayout.Width(75));
		password = GUILayout.PasswordField(password, "*"[0]);
		GUILayout.EndHorizontal();
		
		GUILayout.Space(50);
		
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Login")){login();}
		GUILayout.EndHorizontal();
		
		GUILayout.EndArea();
	}
	
	void login(){
	    WWW www = new WWW (Globals.baseUrl + "login.php?email=" + email + "&pass="+password);	   
		StartCoroutine(WaitForRequest(www));
	}
	
    IEnumerator WaitForRequest(WWW www){
        yield return www;
		int id;
		if(System.Int32.TryParse(www.text, out id)){
			Debug.Log("Logged in as "+id);
			Globals.id = id;
			Application.LoadLevel(1);
		}else{
			Debug.Log ("false");
		}
    }

}
