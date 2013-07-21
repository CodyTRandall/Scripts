using UnityEngine;
using System.Collections;

public class TargetLocator : MonoBehaviour {
	
	void Start(){
		renderer.enabled = false;	
	}
	
	public void SetTarget(){
		renderer.enabled = true;
	}
	
	public void RemoveTarget(){
		renderer.enabled = false;
	}
}
