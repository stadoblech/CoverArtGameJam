using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public int numberOfLives;
    public GameObject enemiesSpawner;

    int numberOfBlinks;
    float blinkDuration;

    SpriteRenderer sr;
    PlayerControlls controlls;

    GameController controller;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start () {
        controller = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>();
        controlls = GetComponent<PlayerControlls>();
        
        numberOfLives = 3;
        numberOfBlinks = 6;
        blinkDuration = 0.1f;
	}

    void OnEnable()
    {
        sr.enabled = true;
    }
	
	void Update () {
	
	}

    public void getHit()
    {
        controller.destroyAllEnemies();
        enemiesSpawner.SetActive(false);
        controlls.enabled = false;
        StartCoroutine(blinking(numberOfBlinks));
    }

    IEnumerator blinking(int i)
    {
        yield return new WaitForSeconds(blinkDuration);
        i--;
        sr.enabled = !sr.enabled;
        if(i < 0)
        {
            StartCoroutine(waitForGameOver());
            yield break;
        }
        StartCoroutine(blinking(i));
    }

    IEnumerator waitForGameOver()
    {
        yield return new WaitForSeconds(1);
        controller.initGameOver();
    }
}
