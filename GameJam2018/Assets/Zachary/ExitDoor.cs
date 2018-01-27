using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

    public GameController game;

    void Awake()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("NPC"))
        {
            if(coll.gameObject.GetComponent<Mover>().panic)
            {
                Destroy(coll.gameObject);
                game.Escape();
            }

        }
    }
}
