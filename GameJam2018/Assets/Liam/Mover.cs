using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private Vector2 velocity;
	private Rigidbody2D rb2d;
	private System.Random randNum = new System.Random();

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		velocity = new Vector2(Random.Range(-50, 50), Random.Range(-50, 50));
		rb2d.AddForce(velocity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
