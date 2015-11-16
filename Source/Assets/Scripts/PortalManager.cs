using UnityEngine;
using System.Collections;

public class PortalManager : MonoBehaviour {

	public GameObject ball;

	private PortalControler [] portals;

	// Use this for initialization
	void Start () {
		portals = this.GetComponentsInChildren<PortalControler> ();
	}
	
	// Update is called once per frame
	void Update () {
		bool isit = false;
		PortalControler p = null;

		foreach (PortalControler portal in portals) {
			if(portal.state){
				isit = true;
				portal.state = false;
				p = portal;
			}
		}
		int jump = Random.Range (0, portals.Length-1);

		if (isit) {
			foreach (PortalControler portal in portals) {
				if(portal != p){
					if(jump == 0)
						ball.transform.position = portal.transform.position;

					jump--;
				}
				portal.timeout = 1;
				portal.state = false;
			}
		}
	}
}
