using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public int initialTime = 100;
	public float time;
	// Use this for initialization
	void Start () {
		time = initialTime;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		time = Mathf.Max(time, 0);
	}
}
