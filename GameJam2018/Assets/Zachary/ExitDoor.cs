using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

    public GameController game;

    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("NPC"))
        {
            Destroy(coll.gameObject);
            game.Escape();
        }
    }
}
