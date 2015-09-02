using UnityEngine;
using System.Collections;

public class BoundCamera : MonoBehaviour {

	GameObject player;
	public GameObject sCam;
	Vector3 sPosition;
	public float smooth = 10;

	void Start(){
		player = GameObject.Find ("Player");
	}

	void Update(){
		transform.position = Vector3.Lerp (transform.position, sCam.transform.position, Time.deltaTime);
		transform.LookAt (player.transform.position);
	}
	
	public void OnTriggerStay(Collider coll){
		transform.position = Vector3.Lerp (transform.position, sCam.transform.position + sCam.transform.forward - sCam.transform.up, Time.deltaTime*smooth);
		//transform.position = transform.position + transform.up*Time.deltaTime*smooth;
	}
}
