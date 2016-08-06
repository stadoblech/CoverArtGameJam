using UnityEngine;
using System.Collections;

public class GhostHeadCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GameController.score += 5;
            transform.root.GetComponent<GhostHandler>().killGhost();
        }
    }
}
