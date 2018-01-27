using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    public GameObject shout;
    public Image black;
    public Animator anim;
    bool transition = false;

    public int score = 0;
    public int level = 1;

    public int peopleSaved = 0;

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
            //bool finished = true;
            foreach (GameObject npc in NPCs)
            {
                //Check all the objects to see when everything has stopped moving
                /*if (npc.GetComponent("Mover").moving)
                    finished = false;*/
                
            }
            if (transition == false)
            {
                StartCoroutine(Fading());
                transition = true;
            }
        }
    }

    IEnumerator Fading()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadSceneAsync("Scene2");
        anim.SetBool("Fade", false);
        hasClicked = false;
        transition = false;
        yield return null;
    }
}
