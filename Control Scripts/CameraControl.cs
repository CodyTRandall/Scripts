using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public int maxx = 100;
	public int maxy = 4;
	public int maxz = 100;
	public Camera camera;
	public float cameraSpeed = 20.0F;
	public float zoomSpeed = 1000.0F;
	
	void Update(){
		//Calculate the new movements
		float z = Input.GetAxis ("Vertical") * cameraSpeed * Time.deltaTime;
		float x = Input.GetAxis ("Horizontal") * cameraSpeed * Time.deltaTime;
		float y = Input.GetAxis ("Zoom") * zoomSpeed * Time.deltaTime;
		
		//If not hitting the border, move
		if( transform.position.x + x < maxx &&
			transform.position.x + x >-maxx &&
			transform.position.z + z < maxz &&
			transform.position.z + z >-maxz
		){
			transform.Translate(x, 0F, z);
		}
		
		//If not zoomed too much, zoom
		Vector3 newVector = camera.transform.position + (Vector3.forward * y);
		if( newVector.y - y < 25 && 
			newVector.y - y > 0
		){
			camera.transform.Translate (Vector3.forward * y);
		}
	}
}
