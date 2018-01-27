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
    public GameObject[] spawnBlocks; //Each block needs to be 3 wide and 3 tall for more or less even distribution
    public GameObject[] spawnPoints;


    bool inGame;
    bool transition = false;
    public int score = 0;
    public int level = 0;
    float time;

    public int peopleSaved = 0;

    public bool hasClicked = false;
    AudioSource gameNoise;

    bool success;

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
        success = false;
        inGame = true;
        hasClicked = false;
        transition = false;
        level++;
        peopleSaved = 0;
        requiredPeople.text = Mathf.Clamp((level - peopleSaved),0, 99).ToString(); //Change the 30 upper bound if we need more....
        time = 0;
        gameNoise = GetComponent<AudioSource>();
        gameNoise.clip = crowd;
        gameNoise.loop = true;
        gameNoise.Play();

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach(GameObject point in spawnPoints)
        {
            switch(Random.Range(0, 10))
            {
                case 0:
                    Instantiate(spawnBlocks[0], point.transform.position, point.transform.rotation);
                    break;
                case 1:
                    Instantiate(spawnBlocks[1], point.transform.position, point.transform.rotation);
                    break;
                case 2:
                    Instantiate(spawnBlocks[2], point.transform.position, point.transform.rotation);
                    break;
                case 3:
                    Instantiate(spawnBlocks[3], point.transform.position, point.transform.rotation);
                    break;
                case 4:
                    Instantiate(spawnBlocks[4], point.transform.position, point.transform.rotation);
                    break;
                case 5:
                    Instantiate(spawnBlocks[5], point.transform.position, point.transform.rotation);
                    break;
                case 6:
                    Instantiate(spawnBlocks[6], point.transform.position, point.transform.rotation);
                    break;
                case 7:
                    Instantiate(spawnBlocks[7], point.transform.position, point.transform.rotation);
                    break;
                case 8:
                    Instantiate(spawnBlocks[8], point.transform.position, point.transform.rotation);
                    break;
                default:
                    Instantiate(spawnBlocks[0], point.transform.position, point.transform.rotation);
                    break;
            };
                    
        }

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
                gameNoise.clip = explosion;
                gameNoise.loop = false;
                gameNoise.Play();
                if (transition == false)
                {
                    if(peopleSaved >= level)
                    {
                        success = true;
                    }
                    StartCoroutine(Fading(success));
                    transition = true;
                    inGame = false;
                }
            }

            RunTimer();
        }
        
    }

    void RunTimer()
    {
        time += Time.deltaTime;
        timer.text = Mathf.Clamp(Mathf.Round(10f - time), 0f, 60f).ToString();
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
        if(score == 1)
            endText.text = ("You saved\n" + score.ToString() + "\nperson!");
        else
            endText.text = ("You saved\n" + score.ToString() + "\npeople!");
        anim = GameObject.Find("BlackScreen").GetComponent<Animator>();

    }

    IEnumerator Fading(bool succeeded)
    {
        //yield return new WaitForSeconds(1f);
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
            SceneManager.LoadSceneAsync("Fail");
            yield return new WaitForSecondsRealtime(0.05f);
            endGame();
        }
        anim.SetBool("Fade", false);
        yield return null;
    }
}
