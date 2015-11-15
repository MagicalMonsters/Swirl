using UnityEngine;

public class Scene1 : MonoBehaviour {

	public GameObject ball;
	public GameObject hole;
	
	public GameObject camera;
	
	public UnityEngine.UI.Text timeTxt;
	
	public int initialSpeed;
	
	private HoleController holeController;
	
	private Timer timer;
	private CameraController cameraController;

	// Use this for initialization
	void Start () {	
		ball.GetComponent<Rigidbody2D>().velocity = (new Vector2(-1.5f/1.8f,-1/1.8f))*initialSpeed;
		holeController = hole.GetComponent<HoleController>();
		timer = GetComponent<Timer>();
		cameraController = camera.GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (timer.time == 0)
		{					
			timeTxt.text = "Game over!" ;
			Time.timeScale = 0;
		}		
		timeTxt.text = "" + (int) timer.time;		
		if (holeController.hasBallEntered)
		{
			timeTxt.text = "You won!" ;
			Time.timeScale = 0;
			cameraController.shouldSink =true;
			//  Application.LoadLevel(1);	
		}
	}
}
