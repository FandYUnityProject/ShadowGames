using UnityEngine;
using System.Collections;

public class ClearBody : MonoBehaviour {

	static Color alpha = new Color(1f,1f,1f,0.5f);

	public static void Clearing(GameObject p){
		p.GetComponent<Renderer>().material.color = alpha;
	}
}
