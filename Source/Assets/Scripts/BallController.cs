using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BallController : MonoBehaviour {

	public float initialSpeed = 80;
	public int initialScore = 0;
	public int scoresTresholdForOpeningHole = 100;

	public Text chargeTxt;
	public Text scoreTxt;
	public GameObject hole;
	public Camera camera;

	private Rigidbody2D rb;
	private AudioSource audio;

	private float score;
	private int charge;
	private int lastHandleHit;

	private float ballRadius;
	
	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		audio = GetComponent<AudioSource>();
		score = initialScore;
		charge = 0;
		ballRadius = 0.3f;
	}

	void Start () {		
		// TODO: should randomly position the ball
		rb.velocity = (new Vector2(-1,1))*initialSpeed;
		// hole.SetActive(false);		
	}

	void Update() {		
		UpdateScore(-Time.deltaTime);				
	}

	void ChangeColor(){

		camera.backgroundColor = Color.red;

	}

	void OnTriggerEnter2D (Collider2D other) {
		GameObject otherGameObject = other.gameObject;		
		if (otherGameObject.CompareTag ("Cash")) {
			otherGameObject.transform.RotateAround (Vector3.zero, new Vector3(0,0,-1), Random.value * 360.0f);			
			float newX = otherGameObject.transform.position.x + Random.Range(-1,1);			
			newX = Mathf.Min(Mathf.Abs(newX), 1.25f) * Mathf.Sign(newX);
			float newY = otherGameObject.transform.position.y + Random.Range(-1,1);			
			newY = Mathf.Min(Mathf.Abs(newY), 1.25f) * Mathf.Sign(newY);
			otherGameObject.transform.position = new Vector3(newX, newY, 0);
			UpdateScore(charge);														
		} else if (otherGameObject.CompareTag ("Hole")) {
			EndGame(true);
		} 
	}

	void OnTriggerExit2D (Collider2D other) {
		GameObject otherGameObject = other.gameObject;		
		Debug.Log("exit trigger tag:"+otherGameObject.tag);
		if (otherGameObject.CompareTag("LeftEdge") || otherGameObject.CompareTag("RightEdge")) {
			transform.position = new Vector3(-transform.position.x + Mathf.Sign(transform.position.x)*(ballRadius*2 + 0.1f),transform.position.y);
			UpdateCharge(0);
		} else if (otherGameObject.CompareTag("UpEdge") || otherGameObject.CompareTag("DownEdge")) {
			transform.position = new Vector3(transform.position.x,-transform.position.y + Mathf.Sign(transform.position.y)*(ballRadius*2 + 0.1f));
			UpdateCharge(0);
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {				
		GameObject otherGameObject = collision.collider.gameObject;
		if (otherGameObject.CompareTag ("Handle1")) {
			UpdateCharge(1);
		} else if (otherGameObject.CompareTag ("Handle2")) {
			UpdateCharge(2);
		} 
	}

	void UpdateScore(float delta) {		
		score += delta;
		score = Mathf.Max(score, 0);
		UpdateScoreText();
		hole.SetActive(score >= scoresTresholdForOpeningHole);	
		if (score == 0) {
			EndGame(false);
		}	
	}

	void UpdateCharge(int typeOfCollider) {
		// wall		
		if (typeOfCollider == 0) {
			charge = System.Math.Max(0, charge - 1);			
		} else {
			int chargeToAdd = 0;
			if (lastHandleHit != 0) {
				chargeToAdd = (lastHandleHit != typeOfCollider) ? 1 : -1;
			}
			charge += chargeToAdd;											
			if (chargeToAdd > 0) {				
				PlayChargeSound();
			}			 	
		}
		lastHandleHit = typeOfCollider;
		UpdateChargeText();
	}

	void EndGame(bool hasWin) {
		string text = hasWin ? "You won!" : "Game over!" ;		
		chargeTxt.text = text;
		Time.timeScale = 0;
	}

	void UpdateChargeText() {
		chargeTxt.text = charge.ToString();
	}

	void UpdateScoreText() {
		scoreTxt.text = ((int)score).ToString();
	}

	void PlayChargeSound() {
		audio.Play();
	}


}
