using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    GameObject GC;
    public void NextLevelButton()
    {
        GC = GameObject.Find("GameController");
        Destroy(GC);
        SceneManager.LoadSceneAsync("Zachary");

    }
}
