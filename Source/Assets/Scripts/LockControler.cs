using UnityEngine;
using System.Collections;

public class LockControler : MonoBehaviour {

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
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D other) {
		GameObject otherGameObject = other.gameObject;		
		if (otherGameObject.CompareTag ("Ball")) {
			if(!state){
				state = true;
				sr.sprite = unlockSprite;
			}
			else{
				state = false;
				sr.sprite = lockSprite;
			}
		} 
	}
}
