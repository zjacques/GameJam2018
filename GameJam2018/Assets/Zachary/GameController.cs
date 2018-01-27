using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject shout;
    public int score = 0;
    public int level = 1;
    public bool hasClicked = false;
    GameObject[] NPCs;

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(transform.gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        NPCs = GameObject.FindGameObjectsWithTag("NPC"); //Get all the characters on screen
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

        if(hasClicked)
        {
            bool finished = true;
            foreach (GameObject npc in NPCs)
            {
                //Check all the objects to see when everything has stopped moving
                /*if (npc.GetComponent("Mover").moving)
                    finished = false;*/
            }
        }
    }
}
