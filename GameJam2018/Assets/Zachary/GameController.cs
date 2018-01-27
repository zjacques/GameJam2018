using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject shout;
    public int score = 0;
    public int level = 1;
    public bool hasClicked = false;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hasClicked == false)
        {
            Debug.Log("Left Click");

            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            Debug.Log(pz);
            Instantiate(shout, pz, Quaternion.identity);
            hasClicked = true;
        }
    }
}
