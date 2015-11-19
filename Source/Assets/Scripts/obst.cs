using UnityEngine;
using System.Collections;

public class obst : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.RotateAround (Vector3.zero, new Vector3(0,0,-1), 15.0f * Time.deltaTime );
	}
}
