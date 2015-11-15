using UnityEngine;

public class CameraController : MonoBehaviour {

	private bool shouldSink = false;
	public GameObject ball;
	
	public float duration = 1.0f;
	public float scaleTreshold = 0.2f;
	
	private Camera camera;
	private double cameraStep;
	 
	private System.Action onSink;

	private double previousTime = 0;	
	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
		cameraStep = camera.orthographicSize / duration;
	}
	
	public void Sink(System.Action sink) {
		shouldSink = true;
		onSink = sink;
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldSink)
		{
			if (camera.orthographicSize < 0.05)
			{
				if (onSink != null)
				{
					onSink();
					onSink = null;
					shouldSink = false;
				}
			} else {
				if (previousTime == 0)
				{
					previousTime = Time.realtimeSinceStartup;	
				} else {
					double delta = Time.realtimeSinceStartup - previousTime;
					previousTime = Time.realtimeSinceStartup;
					camera.orthographicSize -= (float) (delta * cameraStep);
					float step = (1-scaleTreshold)*1.4f/duration;
					ball.transform.localScale /= step;	
				}	
			}									
		}
	}
}
