using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public bool shouldSink = false;
	
	public float duration = 1.0f;
	
	private Camera camera;
	private double step;

	private double previousTime = 0;	
	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
		step = camera.orthographicSize / duration;
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldSink && camera.orthographicSize > 0.05)
		{
			if (previousTime == 0)
			{
				previousTime = Time.realtimeSinceStartup;	
			} else {
				double delta = Time.realtimeSinceStartup - previousTime;
				previousTime = Time.realtimeSinceStartup;
				camera.orthographicSize -= (float) (delta * step);	
			}						
		}
	}
}
