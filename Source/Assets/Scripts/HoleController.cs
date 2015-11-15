using UnityEngine;

public class HoleController : MonoBehaviour {
	
	public bool hasBallEntered = false;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Ball") {
			hasBallEntered = true;
		}
	}
}
