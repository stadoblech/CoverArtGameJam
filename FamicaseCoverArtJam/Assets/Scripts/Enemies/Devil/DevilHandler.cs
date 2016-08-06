using UnityEngine;
using System.Collections;

public class DevilHandler : MonoBehaviour {

    public bool testingDevil;
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

    Transform player;

    PlayerControlls controlls;

    Vector2 playerGroundPosition;
    
    public SpriteRenderer devilSpriteRenderer;

    AudioSource parachuteFallSound;
    void Start()
    {
        parachuteFallSound = GetComponent<AudioSource>();
        devilMode = DevilMode.falling;

        parachute = transform.Find("parachute").gameObject;

        colliders = transform.Find("colliders").gameObject;
        colliders.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        controlls = player.GetComponent<PlayerControlls>();
        playerGroundPosition = controlls.previousPosition;
    }

    void Update()
    {
        switch (devilMode)
        {
            case DevilMode.falling:
                {
                    if(parachute.activeSelf)
                    {
                        transform.position -= new Vector3(0, fallingSpeed * Time.deltaTime);

                        if (transform.position.y <= playerGroundPosition.y && !controlls.jumping)
                        {
                            transform.position = new Vector3(transform.position.x,player.position.y);
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
                    turnAroundDevil();
                    transform.position -= new Vector3(0, fallingSpeed * Time.deltaTime * 4);
                    break;
                }
                
        }
        if (!devilSpriteRenderer.isVisible)
        {
            if(testingDevil)
            {
                return;
            }
            Destroy(gameObject);
        }
    }

    bool turned = false;
    void turnAroundDevil()
    {
        if(!turned)
        {
            parachuteFallSound.Play();
            transform.Rotate(0,0,180);
        }
        turned = true;
    }

    public void killDevil()
    {
        colliders.SetActive(false);
        devilMode = DevilMode.dead;
    }
}
