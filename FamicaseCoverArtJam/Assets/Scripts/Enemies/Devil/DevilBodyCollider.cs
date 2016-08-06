using UnityEngine;
using System.Collections;

public class DevilBodyCollider : MonoBehaviour {

    public Animator devilAnimator;
    public MonoBehaviour enemyHandler;

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<PlayerLife>().getHit();
            GetComponent<AudioSource>().Play();
        }
    }
}
