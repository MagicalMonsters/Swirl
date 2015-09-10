using UnityEngine;
using System.Collections;

public class HandleRotateController : MonoBehaviour
{
	
	public float rotatingSpeed = 10.0f;
		
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetKey ("right")) {						
			transform.RotateAround (Vector3.zero, new Vector3(0,0,-1), rotatingSpeed * Time.deltaTime );
		} else if (Input.GetKey ("left")) {
			transform.RotateAround (Vector3.zero, new Vector3(0,0,1) , rotatingSpeed * Time.deltaTime);			
		}
	}
}
