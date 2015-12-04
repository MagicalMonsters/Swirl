using UnityEngine;
using System.Collections;

public class PortalManager : MonoBehaviour {

	public GameObject ball;

	private PortalController [] portals;

	// Use this for initialization
	void Start () {
		portals = this.GetComponentsInChildren<PortalController> ();
	}
	
	// Update is called once per frame
	void Update () {
		bool isit = false;
		PortalController p = null;

		foreach (PortalController portal in portals) {
			if(portal.state){
				isit = true;
				portal.state = false;
				p = portal;
			}
		}
		int jump = Random.Range (0, portals.Length-1);
		jump /= 2;						
		
		if (isit) {
			foreach (PortalController portal in portals) {
				if(portal != p && portal.CompareTag("portal")){
					if(jump == 0) {
						ball.transform.position = portal.transform.position;						
						Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
						float randx = Random.Range(-1.0f, 1.0f);
						float randy = Random.Range(-1.0f, 1.0f);						
						float mag = rb.velocity.magnitude;												
						rb.velocity = new Vector3(randx, randy,0).normalized * mag;
					}						
					jump--;
				}
				portal.timeout = 1;
				portal.state = false;
			}
		}
	}
}
