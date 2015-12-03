using UnityEngine;

public class Scene2 : MonoBehaviour {
	
	public GameObject ball;
	public GameObject hole;
	public GameObject lock1;
	public GameObject lock2;
	
	public GameObject camera;
	
	public UnityEngine.UI.Text timeTxt;
	public UnityEngine.UI.Text endGame;
	
	public int initialSpeed;
	public int nextSceneIndex = 0;
	
	private HoleController holeController;
	
	private Timer timer;
	private CameraController cameraController;
	private float time3sec;
	private float realTime;
	
	private bool ended = false;
	
	// Use this for initialization
	void Start () {	
		ball.GetComponent<Rigidbody2D>().velocity = (new Vector2(-1.5f/1.8f,-1/1.8f))*initialSpeed;
		holeController = hole.GetComponent<HoleController>();
		timer = GetComponent<Timer>();
		time3sec = 3.0f;
		cameraController = camera.GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {

		hole.SetActive (lock1.GetComponent<LockControler>().state & lock2.GetComponent<LockControler>().state);
		
		if (ended) {
			return;
		}
		
		if (timer.time == 0)
		{					
			timeTxt.text = "" ;
			endGame.text = "Game over!\n"+(int)time3sec;
			Time.timeScale = 0;
			time3sec -= Time.realtimeSinceStartup - realTime;
			time3sec = Mathf.Max(time3sec,0.0f);
			if(time3sec == 0.0f){
				Time.timeScale = 1;
				ended = true;
				Application.LoadLevel(0);
			}
		}		
		timeTxt.text = "" + (int) timer.time;		
		if (holeController.hasBallEntered)
		{
			timeTxt.text = "" ;
			endGame.color = Color.green; 
			endGame.text = "Level: "+nextSceneIndex;
			Time.timeScale = 0;
			ended = true;
			cameraController.Sink(() => {
				Application.LoadLevel(nextSceneIndex);	
				Time.timeScale = 1;
			});				
		}

		realTime = Time.realtimeSinceStartup;
	}
}
