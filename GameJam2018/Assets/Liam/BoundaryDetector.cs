using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDetector : MonoBehaviour {

	private Collider2D m_collider;
	private Vector2 spriteSize;

	// Use this for initialization
	void Start () {
		m_collider = GetComponent<Collider2D> ();
		spriteSize = GetComponent<SpriteRenderer>().bounds.size;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		GameObject other = otherCollider.gameObject;
		if(other.gameObject.CompareTag("NPC"))
		{
			Debug.Log ("Enter");
			double xMax = spriteSize.x / 2.0; // Half as bounds.size.x is the entire width of the collider
			double xMin = -spriteSize.x / 2.0;
			double yMax = spriteSize.y / 2.0;
			double yMin = -spriteSize.y / 2.0;
			Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
			double otherWidth = otherCollider.bounds.size.x / 2.0;
			double otherHeight = otherCollider.bounds.size.y / 2.0;

			Debug.Log (yMin);
			Debug.Log (other.GetComponent<Transform> ().position.y - otherHeight);

			if(other.GetComponent<Transform>().position.x + otherWidth >= xMax && rb.velocity.x > 0)
			{
				rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
				Debug.Log ("Right");
			}
			if(other.GetComponent<Transform>().position.x - otherWidth <= xMin && rb.velocity.x < 0)
			{
				rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
				Debug.Log("Left");
			}
			if(other.GetComponent<Transform>().position.y - otherHeight <= yMin && rb.velocity.y < 0)
			{
				rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
				Debug.Log ("Bottom");
			}
			if(other.GetComponent<Transform>().position.y + otherHeight >= yMax && rb.velocity.y > 0)
			{
				rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
				Debug.Log ("Top");
			}
		}

	}
}