using UnityEngine;
using System.Collections;

public class DevilHeadCollider : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GameController.score += 5;
            transform.root.GetComponent<DevilHandler>().killDevil();
        }
    }
}
