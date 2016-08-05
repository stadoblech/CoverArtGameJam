using UnityEngine;
using System.Collections;

public class ParachuteCollisionHandler : MonoBehaviour {

    public bool parachuteActive;

    BoxCollider2D coll;
    SpriteRenderer sr;

    void Start() {
        coll = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        parachuteActive = true;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            parachuteActive = false;
            disableParachute();
        }
    }

    void disableParachute()
    {
        sr.enabled = false;
        coll.enabled = false;
    }
}
