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

    Transform player;
    Vector2 playerGroundPosition;
    
    public SpriteRenderer devilSpriteRenderer;

    void Start()
    {
        devilMode = DevilMode.falling;

        parachute = transform.Find("parachute").gameObject;

        colliders = transform.Find("colliders").gameObject;
        colliders.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerGroundPosition = player.GetComponent<PlayerControlls>().previousPosition;
    }

    void Update()
    {
        print(playerGroundPosition);
        switch (devilMode)
        {
            case DevilMode.falling:
                {
                    if(parachute.activeSelf)
                    {
                        transform.position -= new Vector3(0, fallingSpeed * Time.deltaTime);
                        
                        if(transform.position.y <= playerGroundPosition.y)
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
