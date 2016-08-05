using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void destroyAllEnemies()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Devil"))
        {
            o.GetComponent<DevilHandler>().enabled = false;
        }
    }

    public void initGameOver()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Devil"))
        {
            Destroy(o);
        }
    }
}
