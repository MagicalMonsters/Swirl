using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public float rotatingSpeed;
	public bool clockwise;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.RotateAround (Vector3.zero, new Vector3(0,0,clockwise?1:-1), rotatingSpeed * Time.deltaTime );
	}
}
