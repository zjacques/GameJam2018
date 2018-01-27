using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicRadiusController : MonoBehaviour {
	void Start () {
		CircleCollider2D c = gameObject.GetComponent<CircleCollider2D> ();
		transform.localScale = new Vector2(c.radius, c.radius);
	}
}
