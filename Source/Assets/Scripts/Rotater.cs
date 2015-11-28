using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour {

	public float rotatingSpeed;
	public bool clockwise;
	public Vector3 center;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.RotateAround (center, new Vector3(0,0,clockwise?1:-1), rotatingSpeed * Time.deltaTime );
	}
}
