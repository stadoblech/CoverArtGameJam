using UnityEngine;
using System.Collections;

public class ParachuteCollisionHandler : MonoBehaviour {

    public bool parachuteActive;


    void Start() {
        parachuteActive = true;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GameController.score += 2;
            gameObject.SetActive(false);
        }
    }
}
