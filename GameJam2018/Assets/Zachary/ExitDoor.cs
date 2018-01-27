using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

    public GameController game;

    void Awake()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("COLLIDED");
        Debug.Log("GOD");
        Debug.Log("DAMN");
        if (coll.gameObject.CompareTag("NPC"))
        {
            if(coll.gameObject.GetComponent<Mover>().panic)
            {
                Destroy(coll.gameObject);
                game.Escape();
            }

        }
    }
}
