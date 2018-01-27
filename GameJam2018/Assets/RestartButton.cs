using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    public GameController GC;
    public void NextLevelButton()
    {
        SceneManager.LoadSceneAsync("Zachary");
        GC.Restart();
    }
}
