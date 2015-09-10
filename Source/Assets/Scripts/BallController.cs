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

	private Rigidbody2D rb;
	private AudioSource audio;

	private float score;
	private int charge;
	private int lastHandleHit;
	
	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		audio = GetComponent<AudioSource>();
		score = initialScore;
		charge = 0;
	}

	void Start () {		
		// TODO: should randomly position the ball
		rb.velocity = (new Vector2(-1,1))*initialSpeed;
		// hole.SetActive(false);		
	}

	void Update() {		
		UpdateScore(-Time.deltaTime);				
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

	void OnCollisionEnter2D (Collision2D collision) {				
		GameObject otherGameObject = collision.collider.gameObject;
		if (otherGameObject.CompareTag ("Handle1")) {
			UpdateCharge(1);
		} else if (otherGameObject.CompareTag ("Handle2")) {
			UpdateCharge(2);
		} else {
			UpdateCharge(0);
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
			UpdateChargeText();
		} else {
			bool shouldCharge  = (lastHandleHit != typeOfCollider && lastHandleHit != 0);
			if (shouldCharge) {
				charge += 1;
				UpdateChargeText();				
				PlayChargeSound();
			}			 			
		}
		lastHandleHit = typeOfCollider;
		Debug.Log("charge: " + charge.ToString());
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
