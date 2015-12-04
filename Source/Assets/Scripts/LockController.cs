using UnityEngine;
using System.Collections;

public class LockController : MonoBehaviour {

	public bool state;
	public Sprite lockSprite;
	public Sprite unlockSprite;
	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		state = false;
		sr = gameObject.GetComponent<SpriteRenderer>();
		sr.sprite = lockSprite;
	}

	void OnCollisionEnter2D (Collision2D other) {
		GameObject otherGameObject = other.gameObject;		
		if (otherGameObject.CompareTag ("Ball")) {
			state = !state;
			sr.sprite = (state) ? unlockSprite : lockSprite;			
		} 
	}
}
