using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	public float panicSpeed;

	private Vector2 velocity;
	private Rigidbody2D rb2d;
	private System.Random randNum = new System.Random();

	private float angle;

	bool panic = false;

	// Use this for initialization
	void Start () {

		transform.GetChild (0).gameObject.SetActive (false);

		angle = Random.Range (0, Mathf.PI * 2);
		velocity = new Vector2 ();
		velocity.x = Mathf.Sin (angle) * speed;
		velocity.y = Mathf.Cos (angle) * speed;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		rb2d.AddForce(velocity);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("NPC"))
		{
			//Vector2 newVelocity = new Vector2 (-gameObject.GetComponent<Rigidbody2D> ().velocity.x, -gameObject.GetComponent<Rigidbody2D> ().velocity.y);
			//gameObject.GetComponent<Rigidbody2D> ().velocity = newVelocity;
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (!panic) 
		{
			Debug.Log ("trig");
			GameObject other = otherCollider.gameObject;

			if (other.gameObject.CompareTag ("Panic")) 
			{
				Vector2 otherPos = otherCollider.gameObject.transform.position;
				Vector2 vecBetween = new Vector2 (transform.position.x - otherPos.x, transform.position.y - otherPos.y); //transform.position - otherPos;
				vecBetween.Normalize();

				float angle = Mathf.PI / 2.0f - Mathf.Atan (vecBetween.y / vecBetween.x);
				vecBetween.x *= panicSpeed;
				vecBetween.y *= panicSpeed;
				rb2d.velocity = new Vector2 ();
				rb2d.AddForce(vecBetween);
				panic = true;
				transform.GetChild (0).gameObject.SetActive (true);
			}
		}
			
	}
}