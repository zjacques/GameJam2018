using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    GameController GC;
    public void NextLevelButton()
    {
        GC = GameObject.Find("GameController").GetComponent<GameController>();
        Destroy(GC);
        SceneManager.LoadSceneAsync("Zachary");

    }
}
