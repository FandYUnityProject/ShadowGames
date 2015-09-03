using UnityEngine;
using System.Collections;

public class BoundCamera : MonoBehaviour {

	GameObject player;
	public GameObject sCam;
	Vector3 sPosition;
	public float smooth = 10;
	bool isTouch = false;

	void Start(){
		player = GameObject.Find ("Player");
	}

	void Update(){
		CameraMove ();
		transform.LookAt (player.transform.position);
	}

	void CameraMove(){
		if (isTouch) {
			transform.position = Vector3.Lerp (transform.position, sCam.transform.position + sCam.transform.forward + sCam.transform.forward - sCam.transform.up, Time.deltaTime * smooth);
		} else {
			transform.position = Vector3.Lerp (transform.position, sCam.transform.position, Time.deltaTime);
		}
	}

	void OnTriggerStay(Collider coll){
		isTouch = true;
		//transform.position = Vector3.Lerp (transform.position, sCam.transform.position + sCam.transform.forward + sCam.transform.forward - sCam.transform.up, Time.deltaTime*smooth);
		//transform.position = transform.position + transform.up*Time.deltaTime*smooth;
	}

	void OnTriggerExit(Collider coll){
		isTouch = false;
	}
}
