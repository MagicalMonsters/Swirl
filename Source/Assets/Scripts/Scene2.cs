﻿using UnityEngine;

public class Scene2 : MonoBehaviour {
	
	public GameObject ball;
	public GameObject hole;
	public GameObject lock1;
	public GameObject lock2;
	
	public GameObject camera;
	
	public UnityEngine.UI.Text timeTxt;
	
	public int initialSpeed;
	public int nextSceneIndex = 0;
	
	private HoleController holeController;
	
	private Timer timer;
	private CameraController cameraController;
	
	private bool ended = false;
	
	// Use this for initialization
	void Start () {	
		ball.GetComponent<Rigidbody2D>().velocity = (new Vector2(-1.5f/1.8f,-1/1.8f))*initialSpeed;
		holeController = hole.GetComponent<HoleController>();
		timer = GetComponent<Timer>();
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
			timeTxt.text = "Game over!" ;
			ended = true;
			Application.LoadLevel(0);

		}		
		timeTxt.text = "" + (int) timer.time;		
		if (holeController.hasBallEntered)
		{
			timeTxt.text = "You won!" ;
			Time.timeScale = 0;
			ended = true;
			cameraController.Sink(() => {
				Application.LoadLevel(nextSceneIndex);	
				Time.timeScale = 1;
			});				
		}
	}
}
