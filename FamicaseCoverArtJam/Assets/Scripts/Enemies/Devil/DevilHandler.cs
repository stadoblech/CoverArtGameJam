using UnityEngine;
using System.Collections;

public class DevilHandler : MonoBehaviour {


    public float fallingSpeed;
    public float movingSpeed;

    enum DevilMode
    {
        falling,
        moving,
        dead
    }

    DevilMode devilMode;

    GameObject colliders;

    GameObject parachute;
    ParachuteCollisionHandler parachuteCollision;

    Transform player;
    float playerDefaultY;

    
    public SpriteRenderer devilSpriteRenderer;

    void Start()
    {
        devilMode = DevilMode.falling;

        parachute = transform.Find("parachute").gameObject;
        parachuteCollision = parachute.GetComponent<ParachuteCollisionHandler>();

        colliders = transform.Find("colliders").gameObject;
        colliders.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerDefaultY = player.position.y;
    }

    void Update()
    {

        switch (devilMode)
        {
            case DevilMode.falling:
                {
                    if(parachuteCollision.parachuteActive)
                    {
                        transform.position -= new Vector3(0, fallingSpeed * Time.deltaTime);
                        if(transform.position.y <= playerDefaultY)
                        {
                            devilMode = DevilMode.moving;
                            parachute.SetActive(false);
                            colliders.SetActive(true);
                        }
                    }
                    else
                    {
                        devilMode = DevilMode.dead;
                    }
                    break;
                }
            case DevilMode.moving:
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y), movingSpeed * Time.deltaTime);
                    break;
                }
            case DevilMode.dead:
                {
                    turnAroundPlayer();
                    transform.position -= new Vector3(0, fallingSpeed * Time.deltaTime * 4);
                    break;
                }
                
        }
        /*
        if (parachute.GetComponent<ParachuteCollisionHandler>().parachuteActive)
        {
            switch (devilMode)
            {
                case DevilMode.falling:
                    {
                        transform.position -= new Vector3(0, fallingSpeed * Time.deltaTime);
                        if (transform.position.y < playerDefaultY)
                        {
                            transform.position = new Vector3(transform.position.x, player.position.y);
                            devilMode = DevilMode.moving;
                            parachute.SetActive(false);
                            colliders.SetActive(true);
                        }

                        break;
                    }
                case DevilMode.moving:
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y), movingSpeed * Time.deltaTime);
                        break;
                    }
            }
        } else
        {
            turnAroundPlayer();
            transform.position -= new Vector3(0, fallingSpeed * Time.deltaTime * 4);

            
        }
        */
        if (!devilSpriteRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    bool turned = false;
    void turnAroundPlayer()
    {
        if(!turned)
        {
            transform.Rotate(0,0,180);
        }
        turned = true;
    }
}
