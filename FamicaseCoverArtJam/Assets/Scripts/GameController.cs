using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public KeyCode continueKey = KeyCode.Space;
    public GameObject player;
    public GameObject enemiesSpawner;
    public Text onScreenText;
    public Text scoreText;

    bool isRunning;
    bool firstRun;

    public static int score;
	void Start () {
        score = 0;
        firstRun = true;
        isRunning = false;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(firstRun)
        {
            onScreenText.text = "How to play\nLeft arrow:move left\nRight arrow:move right\nSpace:jump\nEsc:exit";
        }else
        {
            onScreenText.text = "Game Over\nYour score:"+score+"\nPress space to play again" ;
        }

        if(!isRunning && Input.GetKeyDown(continueKey))
        {
            firstRun = false;
            isRunning = true;
            score = 0;
        }

	    if(isRunning)
        {
            scoreText.text = "Score: " + score; 
            onScreenText.enabled = false;
            scoreText.enabled = true;
            player.SetActive(true);
            enemiesSpawner.SetActive(true);
        }else
        {
            onScreenText.enabled = true;
            scoreText.enabled = false;
            player.SetActive(false);
            enemiesSpawner.SetActive(false);
        }
	}

    public void destroyAllEnemies()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Devil"))
        {
            o.GetComponent<DevilHandler>().enabled = false;
        }

        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Ghost"))
        {
            o.GetComponent<GhostHandler>().enabled = false;
        }
    }

    public void initGameOver()
    {
        
        enemiesSpawner.GetComponent<EnemiesSpawnHandler>().StopAllCoroutines();
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Devil"))
        {
            Destroy(o);
        }

        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Ghost"))
        {
            Destroy(o);
        }
        onScreenText.enabled = true;
        isRunning = false;
    }
}
