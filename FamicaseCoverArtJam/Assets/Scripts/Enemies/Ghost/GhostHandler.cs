using UnityEngine;
using System.Collections;

public class GhostHandler : MonoBehaviour {

    public float ghostSpeed;

    Transform player;

    Vector3 playerDirection;

    bool dead;

    public SpriteRenderer ghostSpriteRenderer;
    public GameObject colliders;

    AudioSource deadGhostSource;

    void Start () {
        deadGhostSource = GetComponent<AudioSource>();
        dead = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player.position.x > transform.position.x)
        {
            playerDirection = new Vector3(1, 0);
        }
        if (player.position.x < transform.position.x)
        {
            playerDirection = new Vector3(-1, 0);
        }


    }

    void Update () {

        if (dead)
        {
            turnAroundDevil();
            colliders.SetActive(false);
            playerDirection = new Vector3(0,-1);
            if (!ghostSpriteRenderer.isVisible)
            {
                Destroy(gameObject);
            }
        }
        transform.position += playerDirection * Time.deltaTime * ghostSpeed;
        
	}

    bool turned = false;
    void turnAroundDevil()
    {
        if (!turned)
        {
            deadGhostSource.Play();
            transform.Rotate(0, 0, 180);
        }
        turned = true;
    }

    public void killGhost()
    {
        dead = true;
        
    }
}
