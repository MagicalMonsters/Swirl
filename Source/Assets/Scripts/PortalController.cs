using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

	public bool state;
	public float timeout;

	// Use this for initialization
	void Start () {
		state = false;
		timeout = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timeout -= Time.deltaTime;
		timeout = Mathf.Max(timeout, 0);
		if (timeout == 0) {
			state = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		GameObject otherGameObject = other.gameObject;		
		if (otherGameObject.CompareTag ("Ball")) {
			if(timeout == 0){
				state = true;
				timeout = 1;
			}
		} 
	}
}
