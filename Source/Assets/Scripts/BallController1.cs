using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BallController1 : MonoBehaviour {
	private float ballRadius;
	private Rigidbody2D rb;	
	void Awake() {
		ballRadius = 0.3f;
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update() {
		if (rb.velocity.magnitude > 4.1) {
			rb.velocity = rb.velocity.normalized * 4;	
		}				
	}

	void OnTriggerExit2D (Collider2D other) {
		GameObject otherGameObject = other.gameObject;		
		Debug.Log("exit trigger tag:"+otherGameObject.tag);
		if (otherGameObject.CompareTag("LeftEdge") || otherGameObject.CompareTag("RightEdge")) {
			transform.position = new Vector3(-transform.position.x + Mathf.Sign(transform.position.x)*(ballRadius*2 + 0.1f),transform.position.y);		
		} else if (otherGameObject.CompareTag("UpEdge") || otherGameObject.CompareTag("DownEdge")) {
			transform.position = new Vector3(transform.position.x,-transform.position.y + Mathf.Sign(transform.position.y)*(ballRadius*2 + 0.1f));
		}
	}	
}
