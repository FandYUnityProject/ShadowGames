using UnityEngine;
using System.Collections;

public class BoundCamera : MonoBehaviour {

	GameObject player;
	Transform t;
	Vector3 pP;
	Vector3 sPosition;

	void Start(){
		sPosition = transform.position;
	}

	void Update(){
		transform.position = Vector3.Lerp (transform.position, sPosition, Time.deltaTime);
	}
	
	public void OnTriggerEnter(Collider coll){
		player = GameObject.Find ("Player");
		Debug.Log(player.transform.position.x);
		transform.position = transform.position + transform.up;
		transform.LookAt (player.transform.position);
		//Quaternion.LookRotation (new Vector3(10,0,0));
		//transform.localRotation = transform.localRotation * new Quaternion (10, 0, 0, 0);
	}
}
