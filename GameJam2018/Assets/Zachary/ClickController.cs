using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour {

    public GameObject shout;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Click");

            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            Debug.Log(pz);
            Instantiate(shout, pz, Quaternion.identity);
        }
	}
}
