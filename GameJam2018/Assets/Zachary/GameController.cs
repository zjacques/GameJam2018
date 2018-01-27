using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject Canvas;
    public GameObject shout;
    public Image black;
    public Animator anim;
    public Text scoreDisplay;
    public Text requiredPeople;
    public Text timer;
    public AudioClip crowd;
    public AudioClip explosion;


    bool inGame;
    bool transition = false;
    public int score = 0;
    public int level = 0;
    float time;

    public int peopleSaved = 0;

    public bool hasClicked = false;
    GameObject[] NPCs;
    AudioSource gameNoise;

    bool success = false;

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(transform.gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        InitLevel();
    }

    void InitLevel()
    {
        NPCs = GameObject.FindGameObjectsWithTag("NPC"); //Get all the characters on screen
        inGame = true;
        hasClicked = false;
        transition = false;
        level++;
        peopleSaved = 0;
        requiredPeople.text = Mathf.Clamp((level - peopleSaved),0, 99).ToString(); //Change the 30 upper bound if we need more....
        time = 0;
        Debug.Log(level);
        gameNoise = GetComponent<AudioSource>();
        gameNoise.clip = crowd;
        gameNoise.Play();
        //requiredPeople.text = ((level - peopleSaved) < 0 ? 0 : (level - peopleSaved)).ToString(); Because I could
    }

    // Update is called once per frame
    void Update()
    {
        if(inGame)
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

            if (time >= 10f)
            {
                if (transition == false)
                {
                    if(peopleSaved >= level)
                    {
                        success = true;
                    }
                    StartCoroutine(Fading(success));
                    transition = true;
                }
            }

            RunTimer();
        }
        
    }

    void RunTimer()
    {
        time += Time.deltaTime;
        timer.text = Mathf.Round(10f - time).ToString();
    }

    public void Escape()
    {
        peopleSaved++;
        score++;
        scoreDisplay.text = score.ToString();
        requiredPeople.text = Mathf.Clamp((level - peopleSaved), 0, 99).ToString();
    }

    void endGame()
    {
        Text endText = GameObject.Find("SavedText").GetComponent<Text>();
        endText.text = ("You saved\n" + score.ToString() + "\npeople!");
        anim = GameObject.Find("BlackScreen").GetComponent<Animator>();

    }

    IEnumerator Fading(bool succeeded)
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        if(succeeded)
        {
            SceneManager.LoadSceneAsync("Scene2");
            InitLevel();
        }
        else
        {
            Destroy(Canvas);
            inGame = false;
            SceneManager.LoadSceneAsync("Fail");
            yield return new WaitForSecondsRealtime(0.05f);
            endGame();
        }
        anim.SetBool("Fade", false);
        yield return null;
    }
}
