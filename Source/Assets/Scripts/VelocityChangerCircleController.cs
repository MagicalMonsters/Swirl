using UnityEngine;
using System.Collections;

public class VelocityChangerCircleController : MonoBehaviour {

	public float fastnessCoefficient = 2f;	
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Ball")
		{
			other.gameObject.GetComponent<Rigidbody2D>().velocity *= fastnessCoefficient;
		}
	}
	
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Ball")
		{
			other.gameObject.GetComponent<Rigidbody2D>().velocity /= fastnessCoefficient;
		}
	}
}
